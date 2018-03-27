using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadAsset : MonoBehaviour {

	public string server_url;

	IEnumerator Start () {

		string url = "file:///Users/matt/Desktop/aws_unity/AnotherWorld/Another.World/AssetsBundle/assetbundle1";

		WWW www = new WWW (url);
		while (!www.isDone) {
			yield return null;
		}

		if (www.assetBundle != null) {
			
			AssetBundle myasset = www.assetBundle;

			string[] all_assets = myasset.GetAllAssetNames ();

			foreach (string assetname in all_assets){
				Debug.Log (assetname.ToString());
			}

			for (int i=0; i <= all_assets.Length; i++){
				GameObject asset = myasset.LoadAsset (all_assets[i]) as GameObject;
				Instantiate (asset);
			}
		}
	}
}