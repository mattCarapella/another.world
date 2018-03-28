using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {



    public float _speed;
    protected Rigidbody _rb;
    public GameObject _game;
    private gameController _controller;
    public GameObject _lastHit;
    public GameObject inhand;
   
    private int _detectRange;
    // Use this for initialization
<<<<<<< HEAD
	void Start () {
//		Vector3 pos = transform.position;
        _speed = 20000f;
		
	}
=======
    void Start () {
        
        _controller = _game.GetComponent<gameController>();
        if (_controller.env == 0)
        {
            _speed = 20000f;
            _detectRange = 500;
        }
        else if (_controller.env == 1)
        {
            _speed = 5000f;
            _detectRange = 50;
        }
    }
>>>>>>> 8672fb13e8846ef18a32777e3f83aea87c711146

    void Awake() {
        _rb = GetComponent<Rigidbody>();

    }
	// Update is called once per frame
	void FixedUpdate () {
<<<<<<< HEAD
//		Debug.Log ("x: " + transform.position.x);
//		Debug.Log ("y: " + transform.position.y);
//		Debug.Log ("z: " + transform.position.z);

        if (!_game.GetComponent<gameController>().CameraDisable)
=======
        if (!_controller.CameraDisable)
>>>>>>> 8672fb13e8846ef18a32777e3f83aea87c711146
        {
            RaycastHit hit;
            Ray dectRay = new Ray(this.transform.position, this.transform.forward);
            Debug.DrawRay(this.transform.position, this.transform.forward * 50);
            if (Physics.Raycast(dectRay,out hit, _detectRange))
            {
                if (hit.collider.gameObject.tag == "World")
                {
                    _lastHit = hit.collider.gameObject;
                    hit.collider.gameObject.GetComponent<Renderer>().material.color = Color.Lerp(Color.red, Color.green, 105f);
                    hit.collider.gameObject.GetComponent<planet>().setRay(true);
                }else if (hit.collider.gameObject.tag == "Asset" && hit.collider.gameObject!=inhand)
                {
                    _lastHit = hit.transform.gameObject;
                    Debug.Log(_lastHit);
                    hit.collider.gameObject.GetComponent<Renderer>().material.color = Color.Lerp(Color.yellow, Color.red, 105f);
                    Debug.Log("hit");
                    
                }
            }
            else if(_lastHit)
            {
                if (_lastHit.tag == "World") {
                    _lastHit.GetComponent<Renderer>().material.color = Color.white;
                    _lastHit.GetComponent<planet>().setRay(false);
                    _lastHit = null;
                }
                else if (_lastHit.tag =="Asset")
                {
                    _lastHit.GetComponent<Renderer>().material.color = Color.white;
                    Debug.Log("hit out");
                    _lastHit = null;
                }
            }
            var x = Input.GetAxis("Horizontal");
            var z = Input.GetAxis("Vertical");
            
            //transform.Translate(x, 0, 0);
            //transform.Translate(0, 0, z);

            Vector3 movement = new Vector3(x * Time.deltaTime * _speed, 0, z * Time.deltaTime * _speed);
            movement = transform.TransformDirection(movement);
            _rb.velocity = (movement);
            
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _controller.place();
                _controller.processObj = inhand;
            }
        }
        
        
    }
    public void reset()
    {
        if (_controller.env == 0)
        {
            _speed = 20000f;
            _detectRange = 500;
        }
        else if (_controller.env == 1)
        {
            _speed = 500f;
            _detectRange = 150;
            inhand.AddComponent<BoxCollider>();
            _lastHit = null;
        }
    }
    void OnTriggerEnter(Collider c)
    {
        if (c.tag =="World")
        {
            Destroy(c.gameObject);
        }
        else if(c.tag =="Asset")
        {
            
        }
    }
    

}
