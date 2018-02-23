using System.Collections;
using UnityEngine;

public class BundleLoader : MonoBehaviour {

    public string cubeAssets, cylinderAssets, matAssets;        // URL of assetbundle file
    AssetBundle cubeBundle, cylinderBundle, matBundle;

	IEnumerator Start () {

        WWW www = new WWW(matAssets);
        yield return www;                       // wait for bundle to be downloaded
        if (www.error != null)
        {
            throw new System.Exception("ERROR: " + www.error);
        }
        matBundle = www.assetBundle;
        matBundle.LoadAllAssets();

        www = new WWW(cubeAssets);
        yield return www;                       // wait for bundle to be downloaded
        if (www.error != null)
        {
            throw new System.Exception("ERROR: " + www.error);
        }
        cubeBundle = www.assetBundle;

        www = new WWW(cylinderAssets);
        yield return www;                       // wait for bundle to be downloaded
        if (www.error != null)
        {
            throw new System.Exception("ERROR: " + www.error);
        }
        cylinderBundle = www.assetBundle;
        print("DOWNLOAD COMPLETE");
    }

    public void SpawnCube(string assetName)
    {
        Instantiate(cubeBundle.LoadAsset("cube"));
    }

    public void SpawnCylinder(string assetName)
    {
        Instantiate(cylinderBundle.LoadAsset("cylinder"));
    }

    public void UnloadAllBundle()
    {
        cubeBundle.Unload(false);
        cylinderBundle.Unload(false);
    }

}

