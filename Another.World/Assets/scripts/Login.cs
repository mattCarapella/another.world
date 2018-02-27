using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Text.RegularExpressions;

public class Login : MonoBehaviour {

    public GameObject email;
    public GameObject password;

    private string Email;
    private string Password;

    string LoginURL = "http://anotherworld.atwebpages.com/Login.php";

    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (email.GetComponent<InputField>().isFocused)
            {
                password.GetComponent<InputField>().Select();
            }
        }

        if (Input.GetKeyDown(KeyCode.Return)) StartCoroutine (LoginToDB(Email, Password));

        Email = email.GetComponent<InputField>().text;
        Password = password.GetComponent<InputField>().text;
    }

    IEnumerator LoginToDB(string username, string password)
    {
        WWWForm form = new WWWForm();
        form.AddField("emailPost", Email);
        form.AddField("passwordPost", Password);

        WWW www = new WWW(LoginURL, form);
        yield return www;
        Debug.Log(www.text);
    }
}
