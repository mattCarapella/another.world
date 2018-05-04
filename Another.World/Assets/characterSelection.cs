using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterSelection : MonoBehaviour {
    public static int chosen = 0;
	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(this.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void chosenOne()
    {
        chosen = 1;
    }
}
