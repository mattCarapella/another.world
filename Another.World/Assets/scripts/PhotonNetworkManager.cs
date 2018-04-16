using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhotonNetworkManager : MonoBehaviour {

	[SerializeField] private Text connectionTest;
	[SerializeField] private GameObject player;
	[SerializeField] private GameObject lobbyCamera;
	[SerializeField] private Transform spawnPoint;
	private string version = "0.2.1";
	private string roomName = "current_room";
  int currentNoOfPeopleInRoom = 0;

	private void Awake ()
	{
		DontDestroyOnLoad (this.gameObject);
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
		PhotonNetwork.JoinOrCreateRoom (roomName, null, null);
	}

	public virtual void OnJoinedRoom()
	{
        if (currentNoOfPeopleInRoom == 20)
        {
            currentNoOfPeopleInRoom = 0;
            int spawnX = Random.Range(-300, 300);
            int spawnY = Random.Range(-150, 360);
            Vector3 newPosition = new Vector3(spawnX, spawnY, 0);
            spawnPoint.position = newPosition;
        }

        PhotonNetwork.Instantiate (player.name, spawnPoint.position, spawnPoint.rotation, 0);
        lobbyCamera.SetActive (false);
        ++currentNoOfPeopleInRoom;
    }

	private void Update ()
	{
		connectionTest.text = PhotonNetwork.connectionStateDetailed.ToString ();
	}
}
