using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateToDatabase : MonoBehaviour {

	string URL = "http://ec2-18-232-184-23.compute-1.amazonaws.com/CreateWorld.php";

	private int userID;
    private string username;
	private string worldName;
	private string worldInfo;
	private int groundToStore;
	private int skyToStore;

	private double x_pos = 0;
	private double y_pos = 0;
	private double z_pos = 0;

	public static int testSkyNum;
	public static int testGoundNum;


	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		userID = Login.send_id;
        username = Login.send_username;
		worldName = SetWorldInfo.Worldname;
		worldInfo = SetWorldInfo.Worldinfo;
		groundToStore = setGround.groundToStore;
		skyToStore = setSkybox.skyToStore;
		

		testSkyNum = skyToStore;
		testGoundNum = groundToStore;
	}

	public void updateDatabase () {
        x_pos = PhotonNetworkManager.x_pos;
        y_pos = PhotonNetworkManager.y_pos;
        z_pos = PhotonNetworkManager.z_pos;
        StartCoroutine(worldUpdate());
	}


	IEnumerator worldUpdate() {
		WWWForm form = new WWWForm();
        /*
		Debug.Log ("================Version 0.0.2===================");
		Debug.Log ("idPost:" + userID);
		Debug.Log ("worldNamePost:" + worldName); //String
		Debug.Log ("worldInfoPost:" + worldInfo); //String
		Debug.Log ("worldSkyPost:" + skyToStore); //Int
		Debug.Log ("worldGroundPost:" + groundToStore);//Int
		Debug.Log ("xPost:" + x_pos);//Int
		Debug.Log ("yPost:" + y_pos);//Int
		Debug.Log ("zPost:" + z_pos);//Int
        */

		form.AddField ("idPost", userID);
        form.AddField ("usernamePost", username);
		form.AddField ("worldNamePost", worldName);
		form.AddField ("worldInfoPost", worldInfo);
		form.AddField ("worldSkyPost", skyToStore);
		form.AddField ("worldGroundPost", groundToStore);
		form.AddField ("xPost", x_pos.ToString());
		form.AddField ("yPost", y_pos.ToString());
		form.AddField ("zPost", z_pos.ToString());



		WWW www = new WWW(URL, form);

		yield return www;
        PhotonNetworkManager.world = int.Parse(www.text);
		//Debug.Log (www.text);
	}
}
