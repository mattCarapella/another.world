using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class screenSetting : MonoBehaviour {
	string URL = "http://ec2-18-232-184-23.compute-1.amazonaws.com/Register.php";
	public void SetFullScreen (bool b) {
		Debug.Log ("Screen Size Changed");
		Screen.fullScreen = b;
	}

}
