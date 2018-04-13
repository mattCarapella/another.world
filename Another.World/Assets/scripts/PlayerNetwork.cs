using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNetwork : MonoBehaviour {

    [SerializeField]
    private Transform playerCam;
    [SerializeField] private gameController _controller;
    [SerializeField]
    private MonoBehaviour[] playerControler;
    [SerializeField]
    

    private PhotonView photonView;

    void Start()
    {
        photonView = GetComponent<PhotonView>();
        initialize();
    }
    private void initialize()
    {
        if (photonView.isMine)
        {
            GetComponent<PhotonVoiceRecorder>().enabled = true;
        }else
        {
            playerCam.gameObject.SetActive(false);
            foreach (MonoBehaviour m in playerControler)
            {
                m.enabled = false;
            }
        }
    }
}
