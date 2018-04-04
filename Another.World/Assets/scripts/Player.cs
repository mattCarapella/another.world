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
    public GameObject game;
    private gameController _controller;
    private static bool created = false;
    private GameObject _player;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        if (!created)
        {
            created = true;
        }else
        {
            Destroy(this.gameObject);
        }
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
    
	IEnumerator loadItems()
	{
		Debug.Log ("********* NOW IN LOADITEMS() *********");
		string url = "http://ec2-18-232-184-23.compute-1.amazonaws.com/assetbundles/asset_bundle_1";
		WWW www = WWW.LoadFromCacheOrDownload(url, 1);

		int itemct = 0;

		while (!www.isDone)
		{
			Debug.Log ("******** DOWNLOADING ASSETBUNDLE ******");

			if (www.assetBundle != null)
			{
				Debug.Log("********* LOADING ASSETS ");

				AssetBundle bundle = www.assetBundle;
//				string[] assetList = bundle.GetAllAssetNames();

				Object[] assets = bundle.LoadAllAssets();
			
		
				foreach (Object asset in assets) {
					Debug.Log ("******** " + asset.name);
					Instantiate (asset, transform.position, transform.rotation);
				}

				itemct++;
			}
		}
		yield return www;
	}


	// Use this for initialization
	void Start () {
        loadPlayer();
		StartCoroutine("loadItems");
        _controller = game.GetComponent<gameController>();
    }
	// Update is called once per frame
	void Update () {
        if (_controller.env==0) {
            x_pos.text = "X: " + inhand.transform.position.x;
            y_pos.text = "Y: " + inhand.transform.position.y;
            z_pos.text = "Z: " + inhand.transform.position.z;
        }
    }
}
