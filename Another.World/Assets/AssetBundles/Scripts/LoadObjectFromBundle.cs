using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadObjectFromBundle : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine ("DownloadObject");
	}
	
	// Update is called once per frame
	IEnumerator DownloadObject () {
		
		WWW www = WWW.LoadFromCacheOrDownload ("file:///" + Application.dataPath + "/AssetBundle", 1);
		yield return www;

		AssetBundle bundle = www.assetBundle;
		AssetBundleRequest request = bundle.LoadAssetAsync<GameObject> ("Cube");

		yield return request;

		GameObject obj = request.asset as GameObject;
		Instantiate<GameObject> (obj);


	}
}
