using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class planet : MonoBehaviour {
    private bool _ray = false;
    public GameObject description;
    public GameObject _game;
    private int _id;
    private string _des;
    private string _owner;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (_ray && Input.GetKeyDown(KeyCode.F))
        {
            description.SetActive(true);
            _game.GetComponent<gameController>().ui_up();
        }
        
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
}
