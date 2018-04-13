using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Text.RegularExpressions;
using System.Security.Cryptography;

public class Registration : MonoBehaviour
{

    public GameObject username;
    public GameObject email;
    public GameObject password;
    public GameObject confirm_password;

    private string Username;
    private string Email;
    private string Password;
    private string Confirm_Password;

    string URL = "http://ec2-18-232-184-23.compute-1.amazonaws.com/Register.php";
    // Use this for initialization
    void Start()
    {

    }

    IEnumerator Register()
    {
        WWWForm form = new WWWForm();
        form.AddField("usernamePost", Username);
        form.AddField("emailPost", Email);
        form.AddField("passwordPost", Password);

        WWW www = new WWW(URL, form);
        yield return www;
        Debug.Log(www.text);
    }

    // Update is called once per frame
    void Update()
    {
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

        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (username.Equals("") || Username == "")
            {
                print("Username field cannot be empty");
            }
            else if (!Email.Contains("@"))
            {
                print("Email field cannot be empty");
            }
            else if (Password != Confirm_Password)
            {
                print("Passwords don't match");
            }
        }

        Username = username.GetComponent<InputField>().text.ToLower();
        Email = email.GetComponent<InputField>().text.ToLower();
        Password = password.GetComponent<InputField>().text;
        Confirm_Password = confirm_password.GetComponent<InputField>().text;

    }

    public void RegisterButton()
    {
        StartCoroutine(Register());
    }
}
