using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Text.RegularExpressions;

public class Registration : MonoBehaviour {

    public GameObject username;
    public GameObject email;
    public GameObject password;
    public GameObject confirm_password;

    private string Username;
    private string Email;
    private string Password;
    private string Confirm_Password;
    
    string CreateUserURL = "http://anotherworld.atwebpages.com/Register.php";

    // Use this for initialization
    void Start () {
		
	}
	
    public void Register(string username, string email, string password, string confirm_password)
    {
        WWWForm form = new WWWForm();
        form.AddField("usernamePost", username);
        form.AddField("emailPost", email);
        form.AddField("passwordPost", password);

        WWW www = new WWW(CreateUserURL, form);
        Debug.Log(www.text);
    }

	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (username.GetComponent<InputField>().isFocused)
            {
                email.GetComponent<InputField>().Select();
            }

            if (email.GetComponent<InputField>().isFocused)
            {
                password.GetComponent<InputField>().Select();
            }

            if (password.GetComponent<InputField>().isFocused)
            {
                confirm_password.GetComponent<InputField>().Select();
            }
        }

        if (Input.GetKeyDown(KeyCode.Return)) // || Input.GetMouseButtonDown(0)
        {
            if (Password == Confirm_Password)
            {
                Register(Username, Email, Password, Confirm_Password);
            }
            else
            {
                print("Password does not match");
            }
        }

        Username = username.GetComponent<InputField>().text;
        Email = email.GetComponent<InputField>().text;
        Password = password.GetComponent<InputField>().text;
        Confirm_Password = confirm_password.GetComponent<InputField>().text;

    }
}
