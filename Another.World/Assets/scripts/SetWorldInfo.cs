using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetWorldInfo : MonoBehaviour {

	public InputField world_Name;
	public InputField world_Info;


	public void setGet () {
		Debug.Log (world_Name.text);
		Debug.Log (world_Info.text);
	}
}
