using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SyncPlace : MonoBehaviour {

	
    void SpawnPlayerEverywhere()
    {
        // You must be in a Room already

        // Manually allocate PhotonViewID
        int id1 = PhotonNetwork.AllocateViewID();

        PhotonView photonView = this.GetComponent<PhotonView>();
        photonView.RPC("SpawnOnNetwork", PhotonTargets.AllBuffered, transform.position, transform.rotation, id1);
    }

    public Transform playerPrefab; //set this in the inspector 

    [PunRPC]
    void SpawnOnNetwork(Vector3 pos, Quaternion rot, int id1)
    {
        Transform newPlayer = Instantiate(playerPrefab, pos, rot) as Transform;

        // Set player's PhotonView
        PhotonView[] nViews = newPlayer.GetComponentsInChildren<PhotonView>();
        nViews[0].viewID = id1;
    }
}
