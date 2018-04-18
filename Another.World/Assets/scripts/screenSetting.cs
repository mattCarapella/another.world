using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class screenSetting : MonoBehaviour {

	public void SetFullScreen (bool b) {
		Debug.Log ("Screen Size Changed");
		Screen.fullScreen = b;
	}

}
