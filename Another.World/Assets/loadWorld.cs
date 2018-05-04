using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loadWorld : MonoBehaviour {

	public int skyNumFromDB;
	public int groundNumFromDB;

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

	public GameObject ground1;
	public GameObject ground2;
	public GameObject ground3;
	public GameObject ground4;


	// Use this for initialization
	void Start () {

    }

	// Update is called once per frame
	void Update () {

	}
    public void attachSkyandGround(int skyNumFromDB, int groundNumFromDB)
    {
       
        //Debug.Log("Gen World with Sky " + skyNumFromDB + " and Ground# " + groundNumFromDB);
        switch (skyNumFromDB)
        {
            case 1:
                RenderSettings.skybox = sky1;
                break;
            case 2:
                RenderSettings.skybox = sky2;
                break;
            case 3:
                RenderSettings.skybox = sky3;
                break;
            case 4:
                RenderSettings.skybox = sky4;
                break;
            case 5:
                RenderSettings.skybox = sky5;
                break;
            case 6:
                RenderSettings.skybox = sky6;
                break;
            case 7:
                RenderSettings.skybox = sky7;
                break;
            case 8:
                RenderSettings.skybox = sky8;
                break;
            case 9:
                RenderSettings.skybox = sky9;
                break;
            case 10:
                RenderSettings.skybox = sky10;
                break;
            case 11:
                RenderSettings.skybox = sky11;
                break;
            case 12:
                RenderSettings.skybox = sky12;
                break;
            case 13:
                RenderSettings.skybox = sky13;
                break;
            case 14:
                RenderSettings.skybox = sky14;
                break;
            case 15:
                RenderSettings.skybox = sky15;
                break;
        }

        switch (groundNumFromDB)
        {
            case 1:
                ground1.SetActive(true);
                break;
            case 2:
                ground2.SetActive(true);
                break;
            case 3:
                ground3.SetActive(true);
                break;
            case 4:
                ground4.SetActive(true);
                break;

        }
    }
}
