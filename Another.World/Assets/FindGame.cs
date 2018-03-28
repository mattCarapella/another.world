using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindGame : MonoBehaviour {

	// Use this for initialization
    
	void Start () {
        
	}
    private static bool created1 = false;
    public GameObject _player;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        if (!created1)
        {
            created1 = true;
        }
        else
        {
            Destroy(this.gameObject);
        }


    }
    // Update is called once per frame
    void Update () {
		
	}
    public void find()
    {
        _player = GameObject.Find("PlayerMate");
        
    }
    public void activePlayer()
    {
        _player.SetActive(true);
    }
}
