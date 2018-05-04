using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SetWorldInfo : MonoBehaviour {
	string URL = "http://ec2-18-232-184-23.compute-1.amazonaws.com/CheckWorldName.php";

	public GameObject submit;
	public GameObject next;

	private static string check = "";

	public GameObject popUp;
	public Text msg;

	public Text worldname;
	public Text worldinfo;
	public int id;

	public static string Worldname;
	public static string Worldinfo;


	public void checkNmae() {
		Worldname = worldname.GetComponent<Text>().text;
		Worldinfo = worldinfo.GetComponent<Text>().text;
		id = Login.send_id;

	
		StartCoroutine(checkFromDatabase());

//		Debug.Log ("check : " + check);
//		Debug.Log ("send_id:" + id); //int
//		Debug.Log ("Worldname:" + Worldname); //Strin
//
//		if (check.Equals("1")) {
//			next.SetActive (true);
//		} else if (check.Equals("0")) {
//			popUp.SetActive (true);
//			msg.text = "World Name is Taken, Please Enter Another Name";
//		} 


	}

	IEnumerator checkFromDatabase() {
		WWWForm form = new WWWForm();
		form.AddField ("idPost", id);
		form.AddField ("worldnamePost", Worldname);
		WWW www = new WWW(URL, form);
		yield return www;
		check = www.text;
		Debug.Log ("check from db : " + check);
		if (check.Equals("0")) {
			next.SetActive (true);
		} else if (check.Equals("1")) {
			popUp.SetActive (true);
			msg.text = "World Name is Taken, Please Enter Another Name";
		} 
	}


	void Update(){

	}

}


