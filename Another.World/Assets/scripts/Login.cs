﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Text.RegularExpressions;
using UnityEngine.SceneManagement;

public class Login : MonoBehaviour
{

    public GameObject email;
    public GameObject password;
    public Text message;
    public GameObject popUp;
    private string Email;
    private string Password;

    public static int send_id = 0;
    public static string send_username = null;
    public static string send_email = null;

    string URL = "http://ec2-18-232-184-23.compute-1.amazonaws.com/Login.php";

    //The amount of time in seconds that should be waited after a succesful login before switching scence, allows the camera to fade
    float start_wait_time;
    private float waitTime = 3;
    private bool beginWaiting = false;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (email.GetComponent<InputField>().isFocused)
            {
                password.GetComponent<InputField>().Select();
            }
        }

        if (Input.GetKeyDown(KeyCode.Return)) LoginButton();

        Email = email.GetComponent<InputField>().text;
        Password = password.GetComponent<InputField>().text;

        if (beginWaiting) {
            if(Time.time - start_wait_time >= 3)
            {
                switchScene(1);
            }
        }
    }

    public void LoginButton()
    {
        if (Email != "" && Password != "")
        {
            StartCoroutine(LoginToDB());
        }
        else
        {
            popUp.SetActive(true);
            message.text = "Fields cannot be empty";
        }
    }

    IEnumerator LoginToDB()
    {
        WWWForm form = new WWWForm();
        form.AddField("emailPost", Email);
        form.AddField("passwordPost", Password);

        WWW www = new WWW(URL, form);
        yield return www;

        string getinfo;
        getinfo = www.text;
        string[] infoparts = getinfo.Split(';');

        string logc = infoparts[0];

        if (logc == "IN")
        {
            
            send_id = int.Parse(infoparts[1]);
            send_username = infoparts[2];
            send_email = infoparts[3];
            //Tell the camera to start fading
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<FadeCamera>().Fade();
            beginWaiting = true;
            start_wait_time = Time.time;
            //switchScene(1);
        }
        else
        {
            popUp.SetActive(true);
            //message.text = "Incorrect Login Info";
            message.text = www.text;
        }

    }

    public void switchScene(int i)
    {
        
        SceneManager.LoadScene(1);
    }

    public void messagebutton()
    {
        popUp.SetActive(false);
    }
}
