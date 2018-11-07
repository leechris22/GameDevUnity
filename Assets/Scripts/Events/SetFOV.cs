using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Sets the volume of the game to the slider value
public class SetFOV : MonoBehaviour {
    private Slider slider;

    private void Start() {
        slider = GetComponent<Slider>();
    }

    public void Setfovval() {
        Data.fov = (int)slider.value;
	}
}
