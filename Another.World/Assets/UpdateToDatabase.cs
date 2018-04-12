using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateToDatabase : MonoBehaviour {

	string URL = "http://ec2-18-232-184-23.compute-1.amazonaws.com/CreateWorld.php";

	private int userID;
	private string worldName;
	private string worldInfo;
	private int groundToStore;
	private int skyToStore;

	private int x_pos;
	private int y_pos;
	private int z_pos;


	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		userID = Login.send_id;
		worldName = SetWorldInfo.Worldname;
		worldInfo = SetWorldInfo.Worldinfo;
		groundToStore = setGround.groundToStore;
		skyToStore = setSkybox.skyToStore;
		x_pos = Player.x_pos;
		y_pos = Player.y_pos;
		z_pos = Player.z_pos;
	}

	public void updateDatabase () {
		StartCoroutine(worldUpdate());
	}


	IEnumerator worldUpdate() {
		WWWForm form = new WWWForm();
		Debug.Log ("================Version 0.0.2===================");
		Debug.Log ("idPost:" + userID);
		Debug.Log ("worldNamePost:" + worldName); //String
		Debug.Log ("worldInfoPost:" + worldInfo); //String
		Debug.Log ("worldSkyPost:" + skyToStore); //Int
		Debug.Log ("worldGroundPost:" + groundToStore);//Int
		Debug.Log ("xPos:" + x_pos);//Int
		Debug.Log ("yPos:" + y_pos);//Int
		Debug.Log ("zPos:" + z_pos);//Int


		form.AddField ("idPost", userID);
		form.AddField ("worldNamePost", worldName);
		form.AddField ("worldInfoPost", worldInfo);
		form.AddField ("worldSkyPost", skyToStore);
		form.AddField ("worldGroundPost", groundToStore);
		form.AddField ("xPos", x_pos);
		form.AddField ("yPos", y_pos);
		form.AddField ("zPos", z_pos);

		WWW www = new WWW(URL, form);

		yield return www;
		Debug.Log (www.text);
	}
}
