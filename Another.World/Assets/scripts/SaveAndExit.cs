using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveAndExit : MonoBehaviour {
	public void saveAndExit() {
		Debug.Log ("AnotherWorld has exit");
		Application.Quit ();
	}
}
