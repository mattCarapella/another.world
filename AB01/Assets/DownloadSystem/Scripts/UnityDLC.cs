using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UnityDLC : MonoBehaviour {

    public string dlcListUrl;

    [Header("UI DLC")]
    public Transform rootDlcContainer;  // Canvas >> DLC List >> ScrollView >> ViewPort >> Content
    public GameObject dlcPrefab;        // Canvas >> DLC List >> ScrollView >> ViewPort >> DLC : Image

    [Header("UI Scene List")]           
    public Transform rootContainer;     // Canvas >> Scene List >> ScrollView >> ViewPort >> Content
    public Button prefab;               // Canvas >> Scene List >> ScrollView >> ViewPort >> SceneButton
    public Text labelText;              // Canvas >> Scene List >> ScrollView >> ViewPort >> SceneButton >> sceneName : Text


    public string[] dlcNames;
    public string[] dlcUrls;

    public static string dlcPath;
    public static UnityDLC main
    {
        get; private set;
    }

    static List<AssetBundle> assetBundles = new List<AssetBundle>();
    static List<string> sceneNames = new List<string>();

    public void Init()
    {
        StartCoroutine(LoadAssets());
    }

    IEnumerator Start()
    {
        main = this;

        // **************** CHANGE TO SERVER ADDRESS ******************
        dlcPath = Application.dataPath + "/DLC/";

        // download dlc list text file
        using (WWW www = new WWW(dlcListUrl))
        {
            yield return www;
            if (!string.IsNullOrEmpty(www.error))
            {
                Debug.LogError(www.error);
                yield break;
            }

            // removes empty lines
            string[] lines = www.text.Split(new string[] { System.Environment.NewLine }, System.StringSplitOptions.RemoveEmptyEntries);
            // get name
            dlcNames = System.Array.ConvertAll(lines, dlc => dlc.Split(new string[] { "<url>" }, System.StringSplitOptions.None)[0]);
            // Gets url
            dlcUrls = System.Array.ConvertAll(lines, dlc => dlc.Split(new string[] { "<url>" }, System.StringSplitOptions.None)[1]);
        }

        // load assets
        Init();
    }

    IEnumerator LoadAssets()
    {
        if (!Directory.Exists(dlcPath))
        {
            Directory.CreateDirectory(dlcPath);
        }

        // unload assets from asset bundle list
        foreach (AssetBundle bundle in assetBundles)
        {
            bundle.Unload(true);
        }

        assetBundles.Clear();
        sceneNames.Clear();

        // get asset bundles from folder
        int i = 0;
        while (i < dlcNames.Length)
        {
            string path = dlcPath + Path.GetFileName(dlcUrls[i]);

            if (File.Exists(path))
            {
                // load bundle
                var bundleRequest = AssetBundle.LoadFromFileAsync(path);
                yield return bundleRequest;

                // add asset bundle to list of asset bundles
                assetBundles.Add(bundleRequest.assetBundle);

                // get scene path for loaded bundle
                sceneNames.AddRange(bundleRequest.assetBundle.GetAllScenePaths());
            }
            i += 1;
            yield return null;
        }

        // Delete unused files
        string[] dlcFiles = Directory.GetFiles(dlcPath);
        foreach (string fileName in dlcFiles)
        {
            if (Path.GetExtension(fileName) != ".meta")
            {
                bool used = false;
                foreach (string url in dlcUrls)
                {
                    if (url.EndsWith(Path.GetFileName(fileName)))
                    {
                        used = true;
                        break;
                    }
                }

                if (!used)
                {
                    File.Delete(fileName);
                }
            }
        }

        RefreshSceneList();
    }

    public void ShowDLC()   // called from download button. called from DLC.cs when download is 
    {
        foreach(Transform t in rootDlcContainer)
        {
            Destroy(t.gameObject);
        }

        for (int i = 0; i < dlcNames.Length; i++)
        {
            var clone = Instantiate(dlcPrefab.gameObject) as GameObject;

            // set parent of instantiated game object to root container of dlc
            clone.transform.SetParent(rootDlcContainer);
            // initialize dlc script
            clone.GetComponent<DLC>().Init(dlcNames[i], dlcUrls[i]);
            // activate game object
            clone.SetActive(true);
        }
    }

    public void RefreshSceneList()      // called when assets are finished loading
    {
        // destroy previous scene list
        foreach (Transform t in rootContainer)
        {
            Destroy(t.gameObject);
        }

        foreach (string sceneName in sceneNames)
        {
            Debug.Log(Path.GetFileNameWithoutExtension(sceneName));
            labelText.text = Path.GetFileNameWithoutExtension(sceneName);
            var clone = Instantiate(prefab.gameObject) as GameObject;
            clone.GetComponent<Button>().AddEventListener(sceneName, LoadAssetBundleScene);
            clone.SetActive(true);
            clone.transform.SetParent(rootContainer);
        }
    }

    public void LoadAssetBundleScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
