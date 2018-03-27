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
    public int env;
    private int _detectRange;
    // Use this for initialization
    void Start () {
        if (env==0) {
            _speed = 20000f;
            _detectRange = 500;
        }else if (env==1)
        {
            _speed = 50f;
            _detectRange = 5;
        }
        _controller = _game.GetComponent<gameController>();
		
	}

    void Awake() {
        _rb = GetComponent<Rigidbody>();

    }
	// Update is called once per frame
	void FixedUpdate () {
        if (!_controller.CameraDisable)
        {
            RaycastHit hit;
            Ray dectRay = new Ray(transform.position, this.transform.forward);
            Debug.DrawRay(transform.position, this.transform.forward * 500);
            if (Physics.Raycast(dectRay,out hit, _detectRange))
            {
                _lastHit = hit.collider.gameObject;
                hit.collider.gameObject.GetComponent<Renderer>().material.color = Color.Lerp(Color.red, Color.green, 105f);
                hit.collider.gameObject.GetComponent<planet>().setRay(true);
                
            }
            else if(_lastHit)
            {
                _lastHit.GetComponent<Renderer>().material.color = Color.white;
                _lastHit.GetComponent<planet>().setRay(false);
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
