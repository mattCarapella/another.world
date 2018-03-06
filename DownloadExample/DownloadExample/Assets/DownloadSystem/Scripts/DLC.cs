using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class DLC : MonoBehaviour {

    // Contains button to download
    [Header("UI")]
    public Image image;
    public Image background;
    public Text nameText;
    public Slider progressBar;
    public Button downloadButton;

    [Header("Appearance")]
    public Color availableColor;    // ready to download color
    public Color downloadedColor;   // downloaded color

    string bundleUrl;
    string filePath;

    public void Init(string dlcName, string dlcUrl)
    {
        nameText.text = dlcName;
        bundleUrl = dlcUrl;
        filePath = UnityDLC.dlcPath + Path.GetFileName(dlcUrl);

        bool downloaded = File.Exists(filePath);
        
        background.color = downloaded ? downloadedColor : availableColor;
        progressBar.value = downloaded ? 1 : 0;
        downloadButton.gameObject.SetActive(!downloaded);
    }

    public void Download()
    {
        // Called when download button is clicked
        StartCoroutine(CoDownload());
    }

    IEnumerator CoDownload()
    {
        downloadButton.gameObject.SetActive(false);
        using(WWW www = new WWW(bundleUrl))
        {
            while (!www.isDone && string.IsNullOrEmpty(www.error))
            {
                // update progress bar
                progressBar.value = www.progress;
                yield return null;
            }

            // check for errors
            if (!string.IsNullOrEmpty(www.error))
            {
                Debug.LogError(www.error);
                yield break;
            }


            // save download to folder
            File.WriteAllBytes(filePath, www.bytes);
        }

        UnityDLC.main.ShowDLC();

    }
}
