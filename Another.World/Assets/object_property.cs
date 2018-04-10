using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(PhotonView))]
public class object_property : Photon.MonoBehaviour {

	// Use this for initialization
    [SerializeField] private string _name;
    [SerializeField]
    private string _price;
    [SerializeField]
    private string _description;
    public GameObject _game;
    private gameController _controller;
    

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
        _game.GetComponent<gameController>().objDes.text = this._description;
        _game.GetComponent<gameController>().objName.text = this._name;
        _game.GetComponent<gameController>().objPrice.text = this._price;
        _game.GetComponent<gameController>().X_pos.text = "X: "+this.transform.position.x;
        _game.GetComponent<gameController>().Y_pos.text = "Y: " + this.transform.position.y;
        _game.GetComponent<gameController>().Z_pos.text = "Z: " + this.transform.position.z;

    }
    // Update is called once per frame
    void Update () {
        if (_ray && Input.GetKeyDown(KeyCode.F) && !_game.GetComponent<gameController>().MenuState && !_game.GetComponent<gameController>().interact && !_game.GetComponent<gameController>().processObj)
        {
            this.attachUI();
            _game.GetComponent<gameController>().obj_description.SetActive(true);
            _game.GetComponent<gameController>().ui_up();
            _game.GetComponent<gameController>().interact = true;
            _game.GetComponent<gameController>().Back.interactable = true;
            
        }
    }
    void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info) {
        if (stream.isWriting) {
            stream.SendNext(_name);
            stream.SendNext(_description);
            stream.SendNext(_price);
        }
        else {
            _name = (string)stream.ReceiveNext();
            _description = (string)stream.ReceiveNext();
            _price = (string)stream.ReceiveNext();

        }
    }

}
