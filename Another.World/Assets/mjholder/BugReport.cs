using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BugReport : MonoBehaviour {

    public GameObject ReportObject;
    public Button submitButton;
    public InputField reportField;
    public Button reportBugToggle;

    string URL = "";

    IEnumerator Report() {
        WWWForm form = new WWWForm();
        form.AddField("reportPost", reportField.text);

        WWW www = new WWW(URL, form);
        yield return www;
}

	public void OpenReportGUI() {
        reportBugToggle.gameObject.SetActive(false);
        ReportObject.SetActive(true);
    }

    public void SubmitBug() {
        reportBugToggle.gameObject.SetActive(true);
        ReportObject.SetActive(false);

        if (reportField.text != "")
            StartCoroutine(Report());
    }
}
