using SFB;
using System;
using System.IO;
using System.Linq;
using UnityEngine;

public class Download : MonoBehaviour {

    private int id = Login.send_id;
    private string username = Login.ftp_user;
    private string password = Login.ftp_password;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void downloadbutton()
    {
        var savepath = StandaloneFileBrowser.OpenFolderPanel("Select the folder where you want to save all of your files ", "", false);

        FTP client = new FTP(@"ftp://18.232.184.23/", username, password);
        string[] listing = client.directoryListSimple(id + "/");
        for (int i = 0; i < listing.Count()-1; i++) {
            client.download(id +"/"+listing[i], savepath[0]+Path.DirectorySeparatorChar+listing[i]);
        }
    }
}
