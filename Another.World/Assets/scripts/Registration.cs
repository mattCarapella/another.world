using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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

    public Text message;
    public GameObject popUp;

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

        if (www.text != "")
        {
            popUp.SetActive(true);
            message.text = www.text;
        }
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

        if (Input.GetKeyDown(KeyCode.Return)) RegisterButton();

        Username = username.GetComponent<InputField>().text.ToLower();
        Email = email.GetComponent<InputField>().text.ToLower();
        Password = password.GetComponent<InputField>().text;
        Confirm_Password = confirm_password.GetComponent<InputField>().text;
    }

    public void RegisterButton()
    {
        if (username.Equals("") || Username == "")
        {
            popUp.SetActive(true);
            message.text = "Username field cannot be empty";
        }
        else if (email.Equals("") || Email == "")
        {
            popUp.SetActive(true);
            message.text = "Email field cannot be empty";
        }
        else if (Password.Length < 8 || Confirm_Password.Length < 8)
        {
            popUp.SetActive(true);
            message.text = "Password has to be longer than 8 characters";
        }
        else if (Password != Confirm_Password)
        {
            popUp.SetActive(true);
            message.text = "Passwords don't match";
        }
        else
        {
            StartCoroutine(Register());
        }
    }

    public void messagebutton()
    {
        popUp.SetActive(false);
    }

    public void switchScene(int i)
    {
        SceneManager.LoadScene(i);
    }
}