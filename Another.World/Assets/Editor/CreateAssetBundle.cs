using UnityEngine;
using UnityEditor;

public class CreateAssetBundles : MonoBehaviour {

	[MenuItem("Assets/Build Asset Bundles")]
	static void BuildAll()
	{
		BuildPipeline.BuildAssetBundles("AssetsBundle", BuildAssetBundleOptions.None, BuildTarget.StandaloneWindows64);
	}
}
