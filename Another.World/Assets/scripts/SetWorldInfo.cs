using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetWorldInfo : MonoBehaviour {

	public Text worldname;
	public Text worldinfo;

	public static string Worldname;
	public static string Worldinfo;

	void Update(){
		Worldname = worldname.GetComponent<Text>().text;
		Worldinfo = worldinfo.GetComponent<Text>().text;
	}
		
}


