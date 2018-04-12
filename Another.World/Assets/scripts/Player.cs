using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Player : MonoBehaviour {

    protected string _name;
    public GameObject inhand;
	public static Text x_pos;
	public static Text y_pos;
	public static Text z_pos;
    public GameObject game;
    private gameController _controller;
    private static bool created = false;
    private GameObject _player;

    void Awake()
    {
        
        

    }

    void loadPlayer()
    {

        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Cube);
        Mesh mesh = sphere.GetComponent<MeshFilter>().sharedMesh;
        Material material = sphere.GetComponent<MeshRenderer>().sharedMaterial;
        inhand.GetComponent<MeshFilter>().mesh = mesh;
        inhand.GetComponent<Renderer>().material = material;
        inhand.transform.position = this.transform.forward * 5+this.transform.position;
        GameObject.Destroy(sphere);
    }
    void loadItems()
    {

    }
	// Use this for initialization
	void Start () {
        loadPlayer();
        loadItems();
        _controller = game.GetComponent<gameController>();
    }
	// Update is called once per frame
	void Update () {
        if (_controller.env==0 && inhand) {
            x_pos.text = "X: " + inhand.transform.position.x;
            y_pos.text = "Y: " + inhand.transform.position.y;
            z_pos.text = "Z: " + inhand.transform.position.z;
        }
        if (GetComponent<PhotonVoiceRecorder>().IsTransmitting)
        {
            Debug.Log("sent");
        }
        if (GetComponent<PhotonVoiceSpeaker>().IsPlaying)
        {
            Debug.Log("read");
        }
    }
}
