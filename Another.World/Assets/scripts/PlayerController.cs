using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// Controls the player's movement in virtual reality.
// [RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour {
	
	/// If true, reset the initial yaw of the player controller when the Hmd pose is recentered.
	public bool HmdResetsY = true;

	/// If true, tracking data from a child OVRCameraRig will update the direction of movement.
	public bool HmdRotatesY = true;

	/// The CameraHeight is the actual height of the HMD and can be used to adjust the height of the character controller, which will affect the
	/// ability of the character to move into areas with a low ceiling.
	[NonSerialized]
	public float CameraHeight;

    public float _speed;
    protected Rigidbody _rb;
    public GameObject _game;
    private gameController _controller;
    public GameObject _lastHit;
    public GameObject inhand;
   
	/// <summary>
	/// This event is raised after the character controller is moved. This is used by the OVRAvatarLocomotion script to keep the avatar transform synchronized
	/// with the OVRPlayerController.
	/// </summary>
	public event Action<Transform> TransformUpdated;

	/// <summary>
	/// This bool is set to true whenever the player controller has been teleported. It is reset after every frame. Some systems, such as 
	/// CharacterCameraConstraint, test this boolean in order to disable logic that moves the character controller immediately 
	/// following the teleport.
	/// </summary>
	[NonSerialized] // This doesn't need to be visible in the inspector.
	public bool Teleported;

	/// <summary>
	/// This event is raised immediately after the camera transform has been updated, but before movement is updated.
	/// </summary>
	public event Action CameraUpdated;

	/// <summary>
	/// This event is raised right before the character controller is actually moved in order to provide other systems the opportunity to 
	/// move the character controller in response to things other than user input, such as movement of the HMD. See CharacterCameraConstraint.cs
	/// for an example of this.
	/// </summary>
	public event Action PreCharacterMove;

	/// <summary>
	/// When true, user input will be applied to linear movement. Set this to false whenever the player controller needs to ignore input for
	/// linear movement.
	/// </summary>
	public bool EnableLinearMovement = true;

	/// <summary>
	/// When true, user input will be applied to rotation. Set this to false whenever the player controller needs to ignore input for rotation.
	/// </summary>
	public bool EnableRotation = true;

	protected CharacterController Controller = null;
	protected OVRCameraRig CameraRig = null;

	private float MoveScale = 1.0f;
	private Vector3 MoveThrottle = Vector3.zero;
	private float FallSpeed = 0.0f;
	private OVRPose? InitialPose;
	public float InitialYRotation { get; private set; }
	private float MoveScaleMultiplier = 1.0f;
	private float RotationScaleMultiplier = 1.0f;
	private bool  SkipMouseRotation = true; // It is rare to want to use mouse movement in VR, so ignore the mouse by default.
	private bool  HaltUpdateMovement = false;
	private bool prevHatLeft = false;
	private bool prevHatRight = false;
	private float SimulationRate = 60f;
	private float buttonRotation = 0f;
	private bool ReadyToSnapTurn; // Set to true when a snap turn has occurred, code requires one frame of centered thumbstick to enable another snap turn.


	//===========================================================================================


    private int _detectRange;
    // Use this for initialization

    void Start () {
        
		// Add eye-depth as a camera offset from the player controller
		var p = CameraRig.transform.localPosition;
		p.z = OVRManager.profile.eyeDepth;
		CameraRig.transform.localPosition = p;

        if (PhotonNetworkManager.world<= 0)
        {
            _speed = 20000f;
            _detectRange = 500;
        }
        else if (PhotonNetworkManager.world > 0)
        {
            _speed = 200f;
            _detectRange = 50;
        }
    }

    void Awake() {
        _controller = _game.GetComponent<gameController>();
        _rb = GetComponent<Rigidbody>();

    }
	// Update is called once per frame
	void FixedUpdate () {

        if (!_controller.CameraDisable)
        {
            RaycastHit hit;
            Ray dectRay = new Ray(this.transform.position, this.transform.forward);
            Debug.DrawRay(this.transform.position, this.transform.forward * 50);
            if (_lastHit)
            {
                //Debug.Log(_lastHit.tag);
                if (_lastHit.tag == "World")
                {
                    _lastHit.GetComponent<Renderer>().material.color = Color.white;
                    _lastHit.GetComponent<planet>().setRay(false);
                    
                    _lastHit = null;
                }
                else if (_lastHit.tag == "Asset")
                {
                    _lastHit.GetComponent<Renderer>().material.color = Color.white;
                    _lastHit.GetComponent<object_property>().setRay(false);
                    Debug.Log("hit out");
                    _lastHit = null;
                }
            }
            if (Physics.Raycast(dectRay,out hit, _detectRange))
            {
                if (hit.collider.gameObject.tag == "World")
                {
                    _lastHit = hit.collider.gameObject;
                    hit.collider.gameObject.GetComponent<Renderer>().material.color = Color.Lerp(Color.red, Color.green, 105f);
                    hit.collider.gameObject.GetComponent<planet>().setRay(true);
                    hit.collider.gameObject.GetComponent<planet>()._game = this._game;
                }
                else if (hit.collider.gameObject.tag == "Asset" && hit.collider.gameObject!=inhand)
                {
                    _lastHit = hit.transform.gameObject;
                    
                    hit.collider.gameObject.GetComponent<Renderer>().material.color = Color.Lerp(Color.yellow, Color.red, 105f);
                    hit.collider.gameObject.GetComponent<object_property>().setRay(true);

                    hit.collider.gameObject.GetComponent<object_property>()._game = this._game;
                    Debug.Log("hit");
                    
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
        else
        {
            _rb.velocity = new Vector3(0,0,0);
        }
        
        
    }
    public void reset()
    {
        Debug.Log(_controller);
            if (PhotonNetworkManager.world<=0)
            {
                _speed = 20000f;
                _detectRange = 500;
            }
            else if (PhotonNetworkManager.world > 0 )
            {
                _speed = 200f;
                _detectRange = 50;
                _lastHit = null;
            }
        
    }
    public void SpawnObject()
    {
        // You must be in a Room already

        // Manually allocate PhotonViewID
        int id1 = PhotonNetwork.AllocateViewID();

        PhotonView photonView = this.GetComponent<PhotonView>();
        int objCode = GetComponent<Player>().getSeleted();
        _game.GetComponent<gameController>().post();
        photonView.RPC("SpawnOnNetwork", PhotonTargets.All, objCode, inhand.transform.position, inhand.transform.rotation, id1, _controller.ObjectDes.text, _controller.ObjectName.text, _controller.ObjectPrice.text);
    }

    
    [PunRPC]
    void SpawnOnNetwork(int objCode, Vector3 pos, Quaternion rot, int id1, string ObjectDes, string ObjectName,string ObjectPrice)
    {
        GameObject Obj = Instantiate(inhand, pos, rot) as GameObject;
        //Debug.Log(objCode);
        if (Obj.transform.childCount>0)
        {
            Destroy(Obj.transform.GetChild(0).gameObject);
        }
        GameObject actual = Instantiate(GetComponent<Player>().loadedAssets[objCode]) as GameObject;

        actual.transform.SetParent(Obj.transform);
        actual.transform.position = Obj.transform.position;
        actual.transform.rotation = Obj.transform.rotation;
        // Set player's PhotonView
        Obj.GetComponent<object_property>().setDescription(ObjectDes);
        Obj.GetComponent<object_property>().setName(ObjectName);
        Obj.GetComponent<object_property>().setPrice(ObjectPrice);
        Obj.AddComponent<BoxCollider>();
        PhotonView v = actual.AddComponent<PhotonView>();
        v.viewID = id1;
        
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
