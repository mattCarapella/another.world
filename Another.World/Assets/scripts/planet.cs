using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class planet : MonoBehaviour {
    private bool _ray = false;
    
    public GameObject _game;
    private int _id;
    private string _des;
    private string _owner;
    private string _name;
    


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (_ray && Input.GetKeyDown(KeyCode.F)&& !_game.GetComponent<gameController>().MenuState && !_game.GetComponent<gameController>().interact && !_game.GetComponent<gameController>().processObj)
        {
            this.attachToUI();
            _game.GetComponent<gameController>()._description.SetActive(true);
            _game.GetComponent<gameController>().ui_up();
            _game.GetComponent<gameController>().interact = true;
            PhotonNetworkManager.world = _id;
            //Debug.Log(PhotonNetworkManager.world);

        }
        
	}
    public string getName()
    {
        return _name;
    }
    public void setName(string name)
    {
        _name = name;
    }
    public int getId()
    {
        return _id;
    }
    public string getDes()
    {
        return _des;
    }
    public string getOwner()
    {
        return _owner;
    }
    public void setId(int id)
    {
        _id = id;
    }
    public void setDes(string des)
    {
        _des = des;
    }
    public void setOwner(string owner)
    {
        _owner = owner;
    }
    public bool getRay()
    {
        return _ray;
    }
    public void setRay(bool ray)
    {
        _ray = ray;
    }
    public void attachToUI()
    {
        _game.GetComponent<gameController>().owner.text = this._owner;
        _game.GetComponent<gameController>().descriptionText.text = this._des;
        _game.GetComponent<gameController>().worldName.text = this._name;
    }
}
