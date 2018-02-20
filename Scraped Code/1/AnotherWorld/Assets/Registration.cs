using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Text.RegularExpressions;
using PlayFab;
using PlayFab.ClientModels;


public class Registration : MonoBehaviour {
    /*
    public GameObject firstname;
    public GameObject lastname;
    public GameObject email;
    public GameObject password;
    public GameObject confirm_password;

    private string Firstname;
    private string Lastname;
    private string Email;
    private string Password;
    private string Confirm_password;
    */

    public InputField username;
    public InputField displayname;
    public InputField email;
    public InputField password;
    public Button create;

    void OnEnable()
    {
        create.onClick.AddListener(Register);
    }

    void OnDisable()
    {
        create.onClick.RemoveAllListeners();
    }

    // Use this for initialization
    /*
    void Start () {
        
	}
    */

	public void Register()
    {
        var request = new RegisterPlayFabUserRequest()
        {
            TitleId = PlayFabSettings.TitleId,
            Username = username.text,
            DisplayName = displayname.text,
            Email = email.text,
            Password = password.text
        };
        
    }

    private void RegisterSuccess(string playfabID)
    {
        
    }
	
    // Update is called once per frame
    /*
	void Update () {

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (firstname.GetComponent<InputField>().isFocused)
            {
                lastname.GetComponent<InputField>().Select();
            }

            if (lastname.GetComponent<InputField>().isFocused)
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

        if (Input.GetKeyDown(KeyCode.Return)){
            Register();
        }

        Firstname = firstname.GetComponent<InputField>().text;
        Lastname = lastname.GetComponent<InputField>().text;
        Email = email.GetComponent<InputField>().text;
        Password = password.GetComponent<InputField>().text;
        Confirm_password = confirm_password.GetComponent<InputField>().text;
    }
    */
}
