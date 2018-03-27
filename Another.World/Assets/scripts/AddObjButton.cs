using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AddObjButton : MonoBehaviour {
	public static bool b0c = false;


	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		
	}

	public void Buttom_Click() {
		Debug.Log ("Button_Click");
		GameObject obj = GameObject.CreatePrimitive (PrimitiveType.Cube);
		obj.transform.localScale += new Vector3(100, 100, 100);
		obj.transform.position = new Vector3 (-2f, 1f, -6f);
	}


}
