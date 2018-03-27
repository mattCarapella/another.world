using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class object_property : MonoBehaviour {

	// Use this for initialization
    private string _name;
    private string _price;
    private string _description;
    public GameObject game;
    private gameController _controller;
    void Start () {
        _controller = game.GetComponent<gameController>();
	}
	
    public void setName(string name)
    {
        _name = name;
    }
    public void setPrice(string price)
    {
        _price = price;
    }
    public void setDescription(string description)
    {
        _description = description;
    }

    public string getName()
    {
        return _name;
    }
    public string getPrice()
    {
        return _price;
    }
    public string getDescription()
    {
        return _description;
    }
	// Update is called once per frame
	void Update () {
        
	}
}
