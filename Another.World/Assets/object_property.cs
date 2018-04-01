using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class object_property : MonoBehaviour {

	// Use this for initialization
    private string _name;
    private string _price;
    private string _description;
    public GameObject _game;
    private gameController _controller;
    public GameObject description;
    public Button Back;
    public Text ObjectName, X_pos,Y_pos,Z_pos;
    public Text ObjectDes;
    public Text ObjectPrice;

    private bool _ray =false;
    void Start () {
        _controller = _game.GetComponent<gameController>();
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
    public void setRay(bool ray)
    {
        _ray = ray;
        if (!_ray)
        {
            _game.GetComponent<gameController>().processObj = null;
        }
    }
    public bool getRay()
    {
        return _ray;
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
    public void attachUI()
    {
        ObjectDes.text = this._description;
        ObjectName.text = this._name;
        ObjectPrice.text = this._price;
        X_pos.text = "X: "+this.transform.position.x;
        Y_pos.text = "Y: " + this.transform.position.y;
        Z_pos.text = "Z: " + this.transform.position.z;

    }
    // Update is called once per frame
    void Update () {
        if (_ray && Input.GetKeyDown(KeyCode.F) && !_game.GetComponent<gameController>().MenuState && !_game.GetComponent<gameController>().interact && !_game.GetComponent<gameController>().processObj)
        {
            this.attachUI();
            description.SetActive(true);
            _game.GetComponent<gameController>().ui_up();
            _game.GetComponent<gameController>().interact = true;
            Back.interactable = true;
            
        }
    }

}
