using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class goToScene : MonoBehaviour
{
    public Text text;
    
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void switchScene(int i)
    {
        if (i ==2 && PhotonNetworkManager.world ==0) {
            
        }else if(i == 4)
        {
            SceneManager.LoadScene(i);
            PhotonNetwork.ReconnectAndRejoin();
        }
        else
        {
            SceneManager.LoadScene(i);
        }
    }
    public void exit() {
        Application.Quit();
    }

}