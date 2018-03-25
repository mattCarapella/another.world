using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    protected string _name;
    public GameObject inhand;

    void loadPlayer()
    {

        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        Mesh mesh = sphere.GetComponent<MeshFilter>().sharedMesh;
        Material material = sphere.GetComponent<MeshRenderer>().sharedMaterial;
        inhand.GetComponent<MeshFilter>().mesh = mesh;
        inhand.GetComponent<Renderer>().material = material;
        inhand.transform.position = this.transform.forward * 10;
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
		
	}
}
