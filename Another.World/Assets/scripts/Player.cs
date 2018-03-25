using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    protected string _name;
    

    void loadPlayer()
    {
        this.gameObject.AddComponent<MeshFilter>();
        this.gameObject.AddComponent<MeshRenderer>();
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        Mesh mesh = sphere.GetComponent<MeshFilter>().sharedMesh;
        Material material = sphere.GetComponent<MeshRenderer>().sharedMaterial;

        this.GetComponent<MeshFilter>().mesh = mesh;
        this.GetComponent<Renderer>().material = material; 
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
