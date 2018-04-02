using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetWorldInfo : MonoBehaviour {
	string URL = "http://ec2-18-232-184-23.compute-1.amazonaws.com/CreateWorld.php";

	public Text worldname;
	public Text worldinfo;

	public static string Worldname;
	public static string Worldinfo;

	void Update(){
		Worldname = worldname.GetComponent<Text>().text;
		Worldinfo = worldinfo.GetComponent<Text>().text;
	}
		
}


