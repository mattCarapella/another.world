using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraLerp : MonoBehaviour {

    // Use this for initialization
    [SerializeField]
    private float speed = 5.0f;
    private Object[] loadedAssets;
    void Awake()
    {
        StartCoroutine(loadItems());
    }
	void Start () {
        StartCoroutine(generateInGame(Random.Range(1, 10)));
        InvokeRepeating("randomizePos",0,30);
	}
	
	// Update is called once per frame
    void randomizePos()
    {
        int x = Random.Range(-500,500);
        int y = Random.Range(50, 100);
        int z = Random.Range(-1000, 500);
        this.transform.position = new Vector3(x,y,z);

    }
    IEnumerator generateInGame(int world)
    {
        string URL = "http://ec2-18-232-184-23.compute-1.amazonaws.com/GetWorldInfo.php";
        //skybox; gound; timespeed "\n"
        //model_id; x; y; z; rx; ry; rz "\n"
        WWWForm form = new WWWForm();
        form.AddField("worldidPost", world);
        WWW www = new WWW(URL, form);
        yield return www;
        //Debug.Log(www.text);
        string response = www.text;
        string[] rows = response.Split('\n');
        string[] fcol = rows[0].Split(';');
        GameObject.Find("GenTheWorld").GetComponent<loadWorld>().attachSkyandGround(int.Parse(fcol[0]), int.Parse(fcol[1]));
        for (int i = 1; i < rows.Length; i++)
        {
            if (rows[i] != "")
            {
                string[] cols = rows[i].Split(';');
                
                GameObject temp = (GameObject)loadedAssets[int.Parse(cols[0])];
                Vector3 pos = new Vector3(float.Parse(cols[1]), float.Parse(cols[2]), float.Parse(cols[3]));
                Vector3 rot = new Vector3(float.Parse(cols[4]), float.Parse(cols[5]), float.Parse(cols[6]));
                //Debug.Log(rot);
                GameObject temp1 = Instantiate(temp);
                temp1.transform.position = pos;
                temp1.transform.rotation = Quaternion.Euler(rot);
            }
        }
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
            

        }
        //Debug.Log("loaded assets " + loadedAssets.Length);

        AssetBundle.UnloadAllAssetBundles(false);
        // GameObject.Find("Test test").GetComponentInChildren<Text>().text = loadedAssets[0].name;
        // GameObject.Find("ExitInventoryMenu").GetComponentInChildren<Text>().text = "*******";


    }
    void Update () {
        this.transform.Translate(new Vector3(0,0,speed)*Time.deltaTime);
        
	}
}
