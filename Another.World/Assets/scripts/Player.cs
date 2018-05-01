using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class Player : MonoBehaviour
{

    protected string _name;
    public GameObject inhand;

    public GameObject game;
    private gameController _controller;
    private static bool created = false;
    private GameObject _player;
    [SerializeField]
    private int selected = 0;
    public Object[] loadedAssets;
    bool dd = false;
    int chosen = 0;

	//Peter0414
	public Text x_pos;
	public Text y_pos;
	public Text z_pos;
	public static double x_Pos2Store;
	public static double y_Pos2Store;
	public static double z_Pos2Store;



    /*---------------Item list genereate---------------------*/
    public GameObject itemList;
    public GameObject itemListItem;

    /*----------------------------------------*/

    void Awake()
    {

        loadPlayer();
        StartCoroutine(loadItems());

    }

    void loadPlayer()
    {
        if (chosen == 0)
        {
            // GameObject.Destroy(GameObject.Find("AWPlayer"));
            // GameObject.Instantiate("MPlayer");

        }
        else if (chosen == 1)
        {

        }
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Cube);
        Mesh mesh = sphere.GetComponent<MeshFilter>().sharedMesh;
        Material material = sphere.GetComponent<MeshRenderer>().sharedMaterial;
        //inhand.GetComponent<MeshFilter>().mesh = mesh;
        //inhand.GetComponent<Renderer>().material = material;
        inhand.transform.position = this.transform.forward * 5 + this.transform.position;
        
        GameObject.Destroy(sphere);
    }
    public void chosenOne()
    {
        chosen = 1;
    }
    IEnumerator loadItems()
    {
        //Debug.Log("********* NOW IN LOADITEMS() *********");
        string url = "http://ec2-18-232-184-23.compute-1.amazonaws.com/assetbundles/asset_bundle_3";
        WWW www = WWW.LoadFromCacheOrDownload(url, 1);

        //int itemct = 0;

        //   while (!www.isDone)
        //   {
        //     Debug.Log("******** DOWNLOADING ASSETBUNDLE ******");

        //            if (www.assetBundle != null)
        //          {
        //            Debug.Log("********* LOADING ASSETS ");
        //
        //          AssetBundle bundle = www.assetBundle;
        //        //				string[] assetList = bundle.GetAllAssetNames();
        //      Object[] assets = bundle.LoadAllAssets();
        //assets = bundle.LoadAllAssets();
        //  loadedAssets = assets;
        //    foreach (Object asset in assets)
        //  {
        //    Debug.Log("******** " + asset.name);
        //  Instantiate(asset, transform.position, transform.rotation);
        //}

        //   itemct++;
        //}
        //}
        yield return www;
        //Debug.Log("current asset bundle " + www.assetBundle);

        if (www.assetBundle != null)
        {
            AssetBundle bundle = www.assetBundle;
            Object[] assets = bundle.LoadAllAssets();
            loadedAssets = assets;
            int idx = 0;
            foreach (Object asset in assets)
            {
                //Debug.Log("******** " + asset.name);
                GameObject temp = Instantiate(itemListItem, itemList.transform);
                temp.GetComponentInChildren<Text>().text = asset.name;
                int ridx = idx;
                temp.GetComponent<Button>().onClick.AddListener(delegate { loadfromInventory(ridx); });
                idx += 1;
                //Instantiate(asset, transform.position, transform.rotation);
            }
            
        }
        //Debug.Log("loaded assets " + loadedAssets.Length);
        
        AssetBundle.UnloadAllAssetBundles(false);
        // GameObject.Find("Test test").GetComponentInChildren<Text>().text = loadedAssets[0].name;
        // GameObject.Find("ExitInventoryMenu").GetComponentInChildren<Text>().text = "*******";


    }
    public void loadfromInventory(int assetNum)
    {

        if (inhand.transform.childCount>0)
        {
            Destroy(inhand.transform.GetChild(0).gameObject);
        }

        GameObject temp = (GameObject)loadedAssets[assetNum];
        selected = assetNum;
        
        //temp.transform.localScale = new Vector3(1, 1, 1);
        Instantiate(loadedAssets[assetNum], inhand.transform.position, inhand.transform.rotation, inhand.transform);
        //inhand = (GameObject)loadedAssets[assetNum];
        Debug.Log(inhand);
        /*  Mesh mesh = temp.GetComponent<MeshFilter>().sharedMesh;
          Material material = temp.GetComponent<MeshRenderer>().sharedMaterial;
          inhand = (GameObject)loadedAssets[assetNum];
          inhand.GetComponent<MeshFilter>().mesh = mesh;
          inhand.GetComponent<Renderer>().material = material;
          inhand.transform.position = this.transform.forward * 5 + this.transform.position;
          Debug.Log("Item placed: " + loadedAssets[assetNum]);
          Destroy(temp);*/
    }

    public void refreshInv()
    {
        GameObject.Find("Item 0").GetComponentInChildren<Text>().text = loadedAssets[0].name;
        GameObject.Find("Item 1").GetComponentInChildren<Text>().text = loadedAssets[1].name;
        GameObject.Find("Item 2").GetComponentInChildren<Text>().text = loadedAssets[2].name;
        GameObject.Find("Item 3").GetComponentInChildren<Text>().text = loadedAssets[3].name;
    }
    // Use this for initialization
    void Start()
    {

        _controller = game.GetComponent<gameController>();
    }
    // Update is called once per frame
    void Update()
    {
		x_Pos2Store = inhand.transform.position.x;
		y_Pos2Store = inhand.transform.position.y;
		z_Pos2Store = inhand.transform.position.z;

        if (inhand)
        {
            x_pos.text = "X: " + inhand.transform.position.x;
            y_pos.text = "Y: " + inhand.transform.position.y;
            z_pos.text = "Z: " + inhand.transform.position.z;
        }
        if (GetComponent<PhotonVoiceRecorder>().IsTransmitting)
        {
            //Debug.Log("sent");
        }
        if (GetComponent<PhotonVoiceSpeaker>().IsPlaying)
        {
            //Debug.Log("read");
        }
    }
    
    public int getSeleted()
    {
        return selected;
    }
}
