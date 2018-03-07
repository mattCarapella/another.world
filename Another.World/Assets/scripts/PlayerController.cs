using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float _speed;
    protected Rigidbody _rb;
    
    // Use this for initialization
	void Start () {
        _speed = 20000f;
		
	}

    void Awake() {
        _rb = GetComponent<Rigidbody>();

    }
	// Update is called once per frame
	void FixedUpdate () {
        
        var x = Input.GetAxis("Horizontal");
        var z = Input.GetAxis("Vertical");
        Debug.Log(x);
        //transform.Translate(x, 0, 0);
        //transform.Translate(0, 0, z);

        Vector3 movement = new Vector3(x * Time.deltaTime * _speed, 0, z * Time.deltaTime * _speed);
        movement = transform.TransformDirection(movement);
        _rb.velocity = (movement);
    }
    

}
