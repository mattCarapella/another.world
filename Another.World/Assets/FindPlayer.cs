using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindPlayer : MonoBehaviour {

	// Use this for initialization
    
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void find()
    {
        FindGame game = GameObject.Find("PlayerMate").GetComponent<FindGame>();
        game.activePlayer();
    }
}
