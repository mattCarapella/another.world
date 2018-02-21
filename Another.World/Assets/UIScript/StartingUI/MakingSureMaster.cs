using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MakingSureMaster : MonoBehaviour {

	public Button yourButton;
	public Toggle yourCha1;
	public Toggle yourCha2;
	public Toggle yourCha3;
	public Toggle yourCha4;
	public InputField yourNameWa;
	public GameObject errName;
	public GameObject errChar;
	// Use this for initialization
	public string nextScene = "PlaceholderScene";

	private AssetBundle myLoadedAssetBundle;
	private string[] scenePaths;

	void Start () {
		Button btn = yourButton.GetComponent<Button>();
		if (yourCha1 == null) {
			btn.onClick.AddListener (checkNameOnly);
		} else {
			btn.onClick.AddListener (checkNameAndCharacter);
		}
		//myLoadedAssetBundle = AssetBundle.LoadFromFile("scene");
		//scenePaths = myLoadedAssetBundle.GetAllScenePaths();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	IEnumerator byePanel(GameObject fadeAway)
	{
		yield return new WaitForSeconds(2);
		fadeAway.SetActive(false);
		yield return null;
		
	}

	void checkNameAndCharacter(){
		if (yourNameWa.text.Length == 0) {
			errName.SetActive(true);
			StartCoroutine(byePanel(errName));
			return;
		}

		if (yourCha1.isOn) {
			print(scenePaths);
			SceneManager.LoadScene(nextScene);
			return;
		}else if(yourCha2.isOn) {
			SceneManager.LoadScene(nextScene);
			return;
		}else if(yourCha3.isOn) {
			SceneManager.LoadScene(nextScene);
			return;
		}else if(yourCha4.isOn) {
			SceneManager.LoadScene(nextScene);
			return;
		}else{
			errChar.SetActive(true);
			StartCoroutine(byePanel(errName));
			return;
		}
	}
	void checkNameOnly(){
		if (yourNameWa.text.Length == 0) {
			errName.SetActive (true);
			StartCoroutine (byePanel (errName));
			return;
		} else {
			SceneManager.LoadScene(nextScene);
		}
	}
}
