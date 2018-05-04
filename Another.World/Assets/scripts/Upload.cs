using SFB;
using System.IO;
using UnityEngine;

public class Upload : MonoBehaviour {

    private int id = Login.send_id;
    private string username = Login.ftp_user;
    private string password = Login.ftp_password;

    private static string[] openpath;
    private static string openfilename;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void uploadbutton(GameObject popUp)
    {
        var extensions = new[] { new ExtensionFilter("3D Object Files ", "fbx", "obj")};
        openpath = StandaloneFileBrowser.OpenFilePanel("Select your File", "", extensions, false);
        openfilename = Path.GetFileName(openpath[0]);

        FTP client = new FTP(@"ftp://18.232.184.23/", username, password);
        client.createDirectory(""+id);
        client.upload(id+"/"+openfilename, openpath[0]);
    }
}
