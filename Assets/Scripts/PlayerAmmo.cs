using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAmmo : MonoBehaviour {
    [SerializeField]
    private GameObject noteprefab;
    private GameObject note;
	
	// Update is called once per frame
	private void Update () {
        if (Input.GetKeyDown(KeyCode.Space)) {
            ShootNote();
        }
    }

    private void ShootNote() {
        note = Instantiate<GameObject>(noteprefab);
        note.name = "note";
        note.transform.SetParent(this.gameObject.transform, false);
    }
}
