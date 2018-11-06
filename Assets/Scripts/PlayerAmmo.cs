using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAmmo : MonoBehaviour {
    public float fireInterval = 0.5f;
    [SerializeField]
    private GameObject noteprefab;
    private GameObject note;
    private bool allowFire = true;

	// Update is called once per frame
	private void Update () {
        if (Input.GetKey(KeyCode.Space) && allowFire) {
            StartCoroutine(ShootNote());
        }
    }

    private IEnumerator ShootNote() {
        allowFire = false;
        note = Instantiate<GameObject>(noteprefab);
        note.name = "note";
        note.transform.position = this.gameObject.transform.position;
        note.transform.rotation = this.gameObject.transform.rotation;
        Vector3 face = note.transform.forward;
        face.y = 0;
        note.GetComponent<Rigidbody>().AddForce(face * 1000);
        yield return new WaitForSeconds(fireInterval);
        allowFire = true;
    }
}
