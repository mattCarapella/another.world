using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class setGround : MonoBehaviour {

	public Image ground1;
	public Image ground2;
	public Image ground3;
	public Image ground4;


	public static int groundToStore;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}
		
	public void b1c() {
		groundToStore = 1;
	}

	public void b2c() {
		groundToStore = 2;
	}

	public void b3c() {
		groundToStore = 3;
	}

	public void b4c() {
		groundToStore = 4;
	}
		

}
