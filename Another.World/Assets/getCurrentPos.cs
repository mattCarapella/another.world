using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public class getCurrentPos : MonoBehaviour {

	public double x_pos;
	public double y_pos;
	public double z_pos;


	public static double x_pos2Store;
	public static double y_pos2Store;
	public static double z_pos2Store;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		x_pos = Player.x_Pos2Store;
		y_pos = Player.y_Pos2Store;
		z_pos = Player.z_Pos2Store;
	}

	public void clickToSavePos() {
		
		x_pos2Store = x_pos;
		y_pos2Store = y_pos;
		z_pos2Store = z_pos;
		Debug.Log ("Current x_pos2Store : " + x_pos2Store);
		Debug.Log ("Current x_pos2Store : " + y_pos2Store);
		Debug.Log ("Current x_pos2Store : " + z_pos2Store);

	}
}
