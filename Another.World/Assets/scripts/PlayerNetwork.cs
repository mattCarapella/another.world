using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNetwork : Photon.MonoBehaviour {

	[SerializeField] private GameObject  playerCamera;
	[SerializeField] private MonoBehaviour[] playerControlScripts;

	private void Start()
	{
		PhotonView photonView = GetComponent<PhotonView>();

		Initialize ();

	}
		
	private void Initialize()
	{
		if (!photonView.isMine) {

			playerCamera.SetActive (false);

			foreach (MonoBehaviour m in playerControlScripts) {
				m.enabled = false;
			}

		}
	}

}
