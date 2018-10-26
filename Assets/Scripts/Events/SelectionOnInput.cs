using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

// Allows for keyboard input on the main menu
public class SelectionOnInput : MonoBehaviour {
    [SerializeField]
    private EventSystem eventSystem;
    [SerializeField]
    private GameObject selectedObject;

    private bool buttonSelected;

    // Update is called once per frame
   private void Update() {
        if (Input.GetAxisRaw("Vertical") != 0 && buttonSelected == false) {
            eventSystem.SetSelectedGameObject(selectedObject);
            buttonSelected = true;
        }
    }

    private void OnDisable() {
        buttonSelected = false;
    }
}