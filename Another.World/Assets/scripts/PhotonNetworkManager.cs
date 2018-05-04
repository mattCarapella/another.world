using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhotonNetworkManager : MonoBehaviour {

	[SerializeField] private Text connectionTest;
	[SerializeField] private GameObject player;
	[SerializeField] private GameObject lobbyCamera;
	[SerializeField] private Transform spawnPoint;
    public static double x_pos;
    public static double y_pos;
    public static double z_pos;

    public static int world = 0;
    public static string version = "0.3.2";
	private string roomName = "current_room";
    private static bool create = false;
    private void Awake()
    {
        if (!create) {
            DontDestroyOnLoad(this.gameObject);
            create = true;
        }
        else
        {
            Destroy(this.gameObject);
        }
	}

	private void Start ()
	{
		PhotonNetwork.ConnectUsingSettings (version);
        UnityVoiceFrontend temp = PhotonVoiceNetwork.Client;
	}

	public virtual void OnJoinedLobby()
	{
		Debug.Log ("Lobby has been joined...");
		RoomOptions roomOptions = new RoomOptions();
		roomOptions.MaxPlayers = 20;
		PhotonNetwork.JoinOrCreateRoom (roomName + world, null, null);
	}

	public virtual void OnJoinedRoom()
	{
	GameObject temp = PhotonNetwork.Instantiate (player.name, spawnPoint.position, spawnPoint.rotation, 0);
        if (world ==0) {
            temp.GetComponent<Player>().game.GetComponent<gameController>().reloadWorld(world);

        }else if (world != -1)
        {
            temp.GetComponent<Player>().game.GetComponent<gameController>().reloadWorld(world);
        }
        
        lobbyCamera.SetActive (false);


	}
	public void disconnect(){
        
        AssetBundle.UnloadAllAssetBundles(true);
		
        PhotonNetwork.Disconnect ();

    }
    void OnDisconnectedFromPhoton()
    {
        lobbyCamera.SetActive(true);
        if (world == -1)
        {
            gameController.loadScene(1);
            lobbyCamera.SetActive(false);
        }
        else if (world == -2)
        {
            gameController.loadScene(0);
            lobbyCamera.SetActive(false);
            world = 0;
        }
        else if (world != 0)
        {
            gameController.loadScene(4);
            connect();
        }else
        {
            gameController.loadScene(2);
            connect();
        }
    }
    public static void connect()
    {
        PhotonNetwork.ConnectUsingSettings(version);

        UnityVoiceFrontend temp = PhotonVoiceNetwork.Client;
    }
	private void Update () 
	{
		connectionTest.text = PhotonNetwork.connectionStateDetailed.ToString ();
	}
    
}
