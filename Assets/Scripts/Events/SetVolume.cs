using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Sets the volume of the game to the slider value
public class SetVolume : MonoBehaviour {
    private Slider slider;

    private void Start() {
        slider = GetComponent<Slider>();
    }

    public void OnValueChanged() {
        AudioListener.volume = (Mathf.Pow(10, slider.value/2)-1) / 100;
    }
}
