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

	private void Awake ()
	{
		DontDestroyOnLoad (this.gameObject);
	}

	private void Start () 
	{
		PhotonNetwork.ConnectUsingSettings (version);	
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
		PhotonNetwork.Instantiate (player.name, spawnPoint.position, spawnPoint.rotation, 0);
		lobbyCamera.SetActive (false);
	}

	private void Update () 
	{
		connectionTest.text = PhotonNetwork.connectionStateDetailed.ToString ();
	}
}
 