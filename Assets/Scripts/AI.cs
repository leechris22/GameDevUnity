using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour {
    // Comparison NPCs
    public Rigidbody player;
    public Rigidbody target;

    // For pursue and evade functions
    public float maxPrediction;
    public float maxAcceleration;

    // For arrive function
    public float maxSpeed;
    public float targetRadiusL;
    public float slowRadiusL;
    public float timeToTarget;

    // For Face function
    public float maxRotation;
    public float maxAngularAcceleration;
    public float targetRadiusA;
    public float slowRadiusA;

    // For wander function
    public float wanderOffset;
    public float wanderRadius;
    public float wanderRate;
    private float wanderOrientation;

    // Holds the path to follow
    public GameObject[] Path;
    public int current = 0;

    protected void Start() {
        player = GetComponent<NPCController>();
    }

    // Calculate the target to pursue
    public void Pursue() {
        Vector3 steering = target.position - player.position;
        steering.y = 0;

        player.AddForce((steering.normalized * maxSpeed) - player.velocity, ForceMode.VelocityChange);
    }

    // Calculate the target to evade
    public void Evade() {
        Vector3 steering = player.position - target.position;
        steering.y = 0;

        player.AddForce((steering.normalized * maxSpeed) - player.velocity, ForceMode.VelocityChange);
    }

    public void Arrive() {
        // Get the direction to the target
        Vector3 direction = target.position - player.position;
        float distance = direction.magnitude;

        // Check if we are there, return no steering
        if (distance < targetRadiusL) {
            player.velocity = Vector3.zero;
        }

        // If we are outside the slowRadius, then go max speed
        // Otherwise calculate a scaled speed
        float targetSpeed = (distance > slowRadiusL ? maxSpeed : maxSpeed * distance / slowRadiusL);

        // Acceleration tries to get to the target velocity
        Vector3 steering = (direction.normalized * targetSpeed - player.velocity) / timeToTarget;

        // Check if the acceleration is too fast
        player.AddForce(Vector3.ClampMagnitude(steering, maxAcceleration), ForceMode.VelocityChange);
    }

    // Calculate the target to face
    public float FaceAway() {
        // Work out the direction to target
        Vector3 direction = character.position - target.position;

        // Check for a zero direction, and make no change if so
        if (direction.magnitude == 0) {
            return 0;
        }

        // Get the naive direction to the target
        float rotation = Mathf.Atan2(direction.x, direction.z) - character.orientation;

        // Map the result to the (0, 2pi) interval
        while (rotation > Mathf.PI) {
            rotation -= 2 * Mathf.PI;
        }
        while (rotation < -Mathf.PI) {
            rotation += 2 * Mathf.PI;
        }
        float rotationSize = Mathf.Abs(rotation);

        // Check if we are there, return no steering
        if (rotationSize < targetRadiusA) {
            character.rotation = 0;
        }

        // If we are outside the slowRadius, then use max rotation
        // Otherwise calculate a scaled rotation
        float targetRotation = (rotationSize > slowRadiusA ? maxRotation : maxRotation * rotationSize / slowRadiusA);

        // The final target rotation combines speed (already in the variable) and direction
        targetRotation *= rotation / rotationSize;

        // Acceleration tries to get to the target rotation
        float angular = targetRotation - character.rotation;
        angular /= timeToTarget;

        // Check if the acceleration is too great
        float angularAcceleration = Mathf.Abs(angular);
        if (angularAcceleration > maxAngularAcceleration) {
            angular /= angularAcceleration;
            angular *= maxAngularAcceleration;
        }

        return angular;
    }

    // Calculate the target to face
    public float Face() {
        var targetDir = sphere.transform.position - transform.position;
        var forward = transform.forward;
        var localTarget = transform.InverseTransformPoint(sphere.transform.position);

        angle = Mathf.Atan2(localTarget.x, localTarget.z) * Mathf.Rad2Deg;

        var eulerAngleVelocity : Vector3 = Vector3(0, angle, 0);
        var deltaRotation : Quaternion = Quaternion.Euler(eulerAngleVelocity * Time.deltaTime);
        rigidbody.MoveRotation(rigidbody.rotation * deltaRotation);

        // Work out the direction to target
        Vector3 direction = target.position - character.position;

        // Check for a zero direction, and make no change if so
        if (direction.magnitude == 0) {
            return 0;
        }

        // Get the naive direction to the target
        float rotation = Mathf.Atan2(direction.x, direction.z) - character.orientation;

        // Map the result to the (0, 2pi) interval
        while (rotation > Mathf.PI) {
            rotation -= 2 * Mathf.PI;
        }
        while (rotation < -Mathf.PI) {
            rotation += 2 * Mathf.PI;
        }
        float rotationSize = Mathf.Abs(rotation);

        // Check if we are there, return no steering
        if (rotationSize < targetRadiusA) {
            character.rotation = 0;
        }

        // If we are outside the slowRadius, then use max rotation
        // Otherwise calculate a scaled rotation
        float targetRotation = (rotationSize > slowRadiusA ? maxRotation : maxRotation * rotationSize / slowRadiusA);

        // The final target rotation combines speed (already in the variable) and direction
        targetRotation *= rotation / rotationSize;

        // Acceleration tries to get to the target rotation
        float angular = targetRotation - character.rotation;
        angular /= timeToTarget;

        // Check if the acceleration is too great
        float angularAcceleration = Mathf.Abs(angular);
        if (angularAcceleration > maxAngularAcceleration) {
            angular /= angularAcceleration;
            angular *= maxAngularAcceleration;
        }

        return angular;
    }

    // Calculate the Path to follow
    public Vector3 PathFollow() {
        Vector3 steering = Vector3.zero;
        if (current >= Path.Length) {
            return steering;
        }
        if ((Path[current].transform.position - character.position).magnitude > targetRadiusL) {
            // Get the direction to the target
            steering = Path[current].transform.position - character.position;

            // Give full acceleration along this direction
            steering.Normalize();
            steering *= maxAcceleration;
        } else {
            current++;
        }
        return steering;
    }

    // Calculate the target to face
    public float pathFace() {
        if (current >= Path.Length) {
            return 0;
        }
        // Work out the direction to target
        Vector3 direction = Path[current].transform.position - character.position;

        // Check for a zero direction, and make no change if so
        if (direction.magnitude == 0) {
            return 0;
        }

        // Get the naive direction to the target
        float rotation = Mathf.Atan2(direction.x, direction.z) - character.orientation;

        // Map the result to the (0, 2pi) interval
        while (rotation > Mathf.PI) {
            rotation -= 2 * Mathf.PI;
        }
        while (rotation < -Mathf.PI) {
            rotation += 2 * Mathf.PI;
        }
        float rotationSize = Mathf.Abs(rotation);

        // Check if we are there, return no steering
        if (rotationSize < targetRadiusA) {
            character.rotation = 0;
        }

        // If we are outside the slowRadius, then use max rotation
        // Otherwise calculate a scaled rotation
        float targetRotation = (rotationSize > slowRadiusA ? maxRotation : maxRotation * rotationSize / slowRadiusA);

        // The final target rotation combines speed (already in the variable) and direction
        targetRotation *= rotation / rotationSize;

        // Acceleration tries to get to the target rotation
        float angular = targetRotation - character.rotation;
        angular /= timeToTarget;

        // Check if the acceleration is too great
        float angularAcceleration = Mathf.Abs(angular);
        if (angularAcceleration > maxAngularAcceleration) {
            angular /= angularAcceleration;
            angular *= maxAngularAcceleration;
        }

        return angular;
    }
}
