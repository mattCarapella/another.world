using UnityEngine;
using UnityEngine.SceneManagement;

public class Logout : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LogoutButton()
    {
        Login.send_id = 0;
        Login.send_username = null;
        Login.send_email = null;
        Login.ftp_user = null;
        Login.ftp_password = null;

        switchScene(0);
    }

    public void switchScene(int i)
    {
        SceneManager.LoadScene(i);
    }
}
