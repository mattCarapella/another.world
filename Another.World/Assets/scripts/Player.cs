using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Player : MonoBehaviour {

    protected string _name;
    public GameObject inhand;
    public Text x_pos;
    public Text y_pos;
    public Text z_pos;


    void loadPlayer()
    {

        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Cube);
        Mesh mesh = sphere.GetComponent<MeshFilter>().sharedMesh;
        Material material = sphere.GetComponent<MeshRenderer>().sharedMaterial;
        inhand.GetComponent<MeshFilter>().mesh = mesh;
        inhand.GetComponent<Renderer>().material = material;
        inhand.transform.position = this.transform.forward * 5;
        GameObject.Destroy(sphere);
    }
    void loadItems()
    {

    }
	// Use this for initialization
	void Start () {
        loadPlayer();
        loadItems();
	}
	// Update is called once per frame
	void Update () {
        x_pos.text = "X: " + inhand.transform.position.x;
        y_pos.text = "Y: " + inhand.transform.position.y;
        z_pos.text = "Z: " + inhand.transform.position.z;
    }
}
