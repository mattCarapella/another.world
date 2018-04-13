using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setSkybox : MonoBehaviour {
	string URL = "http://ec2-18-232-184-23.compute-1.amazonaws.com/Register.php";
	public static Material sky0;
	public Material sky1;
	public Material sky2;
	public Material sky3;
	public Material sky4;
	public Material sky5;
	public Material sky6;
	public Material sky7;
	public Material sky8;
	public Material sky9;
	public Material sky10;
	public Material sky11;
	public Material sky12;
	public Material sky13;
	public Material sky14;
	public Material sky15;
    public Terrain t;

	public static int skyToStore;

	// Use this for initialization
	void Start () {
		RenderSettings.skybox = sky1;
        
	}
		

	// Update is called once per frame
	void Update () {
//		Debug.Log (skyToStore);
	}
		

	public void b1c() {
		RenderSettings.skybox = sky1;
        
		skyToStore = 1;
	}
	public void b2c() {
		RenderSettings.skybox = sky2;
		skyToStore = 2;
	}
	public void b3c() {
		RenderSettings.skybox = sky3;
		skyToStore = 3;
	}
	public void b4c() {
		RenderSettings.skybox = sky4;
		skyToStore = 4;
	}
	public void b5c() {
		RenderSettings.skybox = sky5;
		skyToStore = 5;
	}
	public void b6c() {
		RenderSettings.skybox = sky6;
		skyToStore = 6;
	}
	public void b7c() {
		RenderSettings.skybox = sky7;
		skyToStore = 7;
	}
	public void b8c() {
		RenderSettings.skybox = sky8;
		skyToStore = 8;
	}
	public void b9c() {
		RenderSettings.skybox = sky9;
		skyToStore = 9;
	}
	public void b10c() {
		RenderSettings.skybox = sky10;
		skyToStore = 10;
	}
	public void b11c() {
		RenderSettings.skybox = sky11;
		skyToStore = 11;
	}
	public void b12c() {
		RenderSettings.skybox = sky12;
		skyToStore = 12;
	}
	public void b13c() {
		RenderSettings.skybox = sky13;
		skyToStore = 13;
	}
	public void b14c() {
		RenderSettings.skybox = sky14;
		skyToStore = 14;
	}
	public void b15c() {
		RenderSettings.skybox = sky15;
		skyToStore = 15;
	}

}
