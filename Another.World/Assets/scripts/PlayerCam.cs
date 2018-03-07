using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour {
    protected Transform _current_pos;
    protected Transform _current_parent_pos;

    protected Vector3 _rotation;
    public float MouseSen = 4f;
    public float OrbitDampening = 10f;

    public bool CameraDisable = false;

    // Use this for initialization
    void Start () {
        _current_parent_pos = this.transform.parent;
        _current_pos = this.transform;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (Input.GetKeyDown(KeyCode.LeftShift)) {
            CameraDisable = !CameraDisable;
        }
        if (!CameraDisable)
        {
            if (Input.GetAxis("Mouse X")!=0 || Input.GetAxis("Mouse Y")!=0)
            {
                _rotation.x += Input.GetAxis("Mouse X") * MouseSen;
                _rotation.y -= Input.GetAxis("Mouse Y") * MouseSen;

                _rotation.y = Mathf.Clamp(_rotation.y,-90f,90f);
            }
        }
        Quaternion Qt = Quaternion.Euler(_rotation.y, _rotation.x, 0);
        this._current_parent_pos.rotation = Quaternion.Lerp(this._current_parent_pos.rotation, Qt, Time.deltaTime * OrbitDampening);
	}
}
