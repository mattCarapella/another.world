using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public static class ButtonExtension
{
    public static void AddEventListener<T> (this Button button, T param, Action<T> OnClick)
    {
        // Adds event listener to button
        button.onClick.AddListener(delegate
        {
            OnClick(param);
        });
    }
}

public class AssetBundleScene : MonoBehaviour
{
    public string[] urls;      // address to asset bundle files

    [Header("UI Stuff")]
    public Transform rootContainer;
    public Button prefab;
    public Text labelText;

    static List<AssetBundle> assetBundles = new List<AssetBundle>();
    static List<string> sceneNames = new List<string>();       // full scene path stored here

    // download asset bundle on start
    IEnumerator Start()
    {
        // if asset bundle has not been downloaded, get it first 
        if (assetBundles.Count == 0)
        {
            int i = 0;
            while (i < urls.Length)
            {
                using (WWW www = new WWW(urls[i]))
                {
                    yield return www;           // wait for DL to complete
                    if (!String.IsNullOrEmpty(www.error))
                    {
                        Debug.Log(www.error);
                        yield break;
                    }
                    assetBundles.Add(www.assetBundle);                          // add asset bundle to list of ABs
                    sceneNames.AddRange(www.assetBundle.GetAllScenePaths());
                }
                i += 1;
            }
        }
    }

    public void LoadAssetBundleScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}