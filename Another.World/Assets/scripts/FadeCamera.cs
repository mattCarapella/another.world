using System.Collections;
using System.Collections.Generic;
using UnityEngine;



//Fades the camera and rotates it upwards 
//This script should be attached to the MainCamera
//Call the Fade function from a different script to begin the fading
public class FadeCamera : MonoBehaviour {
    private bool begin = false;
    private float alphaFadeValue = 0;
    private Texture2D whiteTexture;
    private float rotatation = -2;
    private float start_rot;
    // Use this for initialization
    void Start () {
        whiteTexture = Texture2D.whiteTexture;
        start_rot = transform.rotation.eulerAngles.x;
    }
	
	// Update is called once per frame
	void Update () {
        if (begin)
        {
            
            //rotatation -= (rotatation*Time.deltaTime);
            transform.Rotate(10*Vector3.left * Time.deltaTime);
        }
	}

    public void Fade() {
        begin = true;
        
    }


    void OnGUI()
    {
        if (begin)
        {
            alphaFadeValue += Mathf.Clamp01(Time.deltaTime / 5);


            GUI.color = new Color(1, 1, 1, alphaFadeValue);
            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), whiteTexture);
        }

    }



}
