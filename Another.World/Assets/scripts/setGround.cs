using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class setGround : MonoBehaviour {

	public static Image groundToStore;
	public Image ground1;
	public Image ground2;
	public Image ground3;
	public Image ground4;

	// Use this for initialization
	void Start () {
		groundToStore = ground1;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void b1c() {
		groundToStore = ground1;
	}

	public void b2c() {
		groundToStore = ground2;
	}

	public void b3c() {
		groundToStore = ground3;
	}

	public void b4c() {
		groundToStore = ground4;
	}

	public void nextButtonClicked() {
		//To save info here
	}

}
