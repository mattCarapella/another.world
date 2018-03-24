using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float _speed;
    protected Rigidbody _rb;
    public GameObject _game;
    public GameObject _lastHit;
    // Use this for initialization
    void Start () {
        _speed = 20000f;
		
	}

    void Awake() {
        _rb = GetComponent<Rigidbody>();

    }
	// Update is called once per frame
	void FixedUpdate () {
        if (!_game.GetComponent<gameController>().CameraDisable)
        {
            RaycastHit hit;
            Ray dectRay = new Ray(transform.position, this.transform.forward);
            Debug.DrawRay(transform.position, this.transform.forward * 500);
            if (Physics.Raycast(dectRay,out hit, 500))
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
            Debug.Log(x);
            //transform.Translate(x, 0, 0);
            //transform.Translate(0, 0, z);

            Vector3 movement = new Vector3(x * Time.deltaTime * _speed, 0, z * Time.deltaTime * _speed);
            movement = transform.TransformDirection(movement);
            _rb.velocity = (movement);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                sphere.transform.position = this.transform.position;
                Instantiate(sphere);
            }
        }
        
        
    }
    void OnTriggerEnter(Collider c)
    {
        if (c.tag =="World")
        {
            Debug.Log(c.gameObject.GetComponent<planet>().getId());
            Destroy(c.gameObject);
        }
        else if(c.tag =="Asset")
        {
            
        }
    }
    

}
