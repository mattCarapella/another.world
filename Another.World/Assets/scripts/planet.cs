using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class planet : MonoBehaviour {
    private bool MouseOver = false;
    public GameObject description;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (MouseOver) {
            this.GetComponent<Renderer>().material.color = Color.Lerp(Color.red, Color.green,105f);
        }
	}
    void OnMouseEnter()
    {
        MouseOver = true;
    }
    void OnMouseExit()
    {
        MouseOver = false;
        this.GetComponent<Renderer>().material.color = Color.white;
    }
    void OnMouseDown()
    {
        //this.GetComponent<Renderer>().material.color = Color.yellow;
        description.SetActive(true);
    }
}
