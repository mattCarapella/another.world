using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameController:MonoBehaviour{

    public GameObject Menu;
    public bool CameraDisable =false;
    public bool MouseVisiable = false;
    public bool MenuState = false;
    public GameObject placement;
    public bool place_status;
    public Button confirm;
    public GameObject processObj;
    public GameObject worldModelSample;
    public GameObject _description;
    public GameObject listItem;
    public GameObject listView;
    public Text owner;
    public Text descriptionText;
    public Text worldName;
    private IDictionary<int, int> keymap;
    
    
    
    void Start()
    {
        place_status = false;
        keymap = new Dictionary<int, int>();
        for (int i=97;i<123;i++)
        {
            keymap[i] = 0;
        }
        StartCoroutine(generateWorld());
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            CameraDisable = !CameraDisable;
        }
        if (!MouseVisiable)
        {
            Cursor.visible = false;
        }
        else
        {
            Cursor.visible = true;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            MenuState = !MenuState;
            Menu.SetActive(MenuState);
            CameraDisable = !CameraDisable;
            MouseVisiable = !MouseVisiable;

        }
        if (processObj)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                keymap[(int)KeyCode.Q] = 1;
            }
            if (Input.GetKeyUp(KeyCode.Q))
            {
                keymap[(int)KeyCode.Q] = 0;
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                keymap[(int)KeyCode.E] = 1;
            }
            if (Input.GetKeyUp(KeyCode.E))
            {
                keymap[(int)KeyCode.E] = 0;
            }
            if (keymap[(int)KeyCode.Q]==1)
            {
                processObj.transform.Rotate(Vector3.up, Time.deltaTime*50f);
                Debug.Log(processObj.transform.rotation);
            }
            else if (keymap[(int)KeyCode.E] == 1)
            {
                processObj.transform.Rotate(Vector3.down, Time.deltaTime*50f);
            }
        }

    }
    IEnumerator generateWorld() {
        string URL = "http://ec2-18-232-184-23.compute-1.amazonaws.com/GetWorldInfo.php";
        WWW www = new WWW(URL);
        Debug.Log(URL);
        yield return www;
        string response = www.text;
        Debug.Log(response);
        string[] rows = response.Split('\n');

        foreach (string row in rows)
        {
            Debug.Log(row);
            string[] cols = row.Split(';');
            int worldId = int.Parse(cols[0]);
            int userId = int.Parse(cols[1]);
            string title = cols[2];
            string description = cols[3];
            float x = float.Parse(cols[4]);
            float y = float.Parse(cols[5]);
            float z = float.Parse(cols[6].Split(' ')[0]);

            Debug.Log(x);
            GameObject temp = Instantiate(worldModelSample);
            temp.GetComponent<planet>()._game = this.gameObject;
            temp.GetComponent<planet>().description = _description;
            temp.transform.position= new Vector3(x,y,z);
            planet sample = temp.GetComponent<planet>();
            sample.owner = owner;
            sample.descriptionText = descriptionText;
            sample.worldName = worldName;
            sample.setDes(description);
            sample.setId(worldId);
            sample.setOwner(userId.ToString());
            sample.setName(title);
            addEntryToList(title, x,y,z);




        }
    }
    public void ui_up()
    {
        CameraDisable = true;
        MouseVisiable = true;
    }

    public void ui_down()
    {
        CameraDisable = false;
        MouseVisiable = false;
    }

    public void place()
    {

        Debug.Log(place_status);
        confirm.interactable = true;
        if (place_status==false) {
            placement.SetActive(true);
            this.ui_up();
            place_status = true;
        }
    }
    public void place_request(GameObject inhand)
    {
        Debug.Log(place_status);
        if (place_status==true)
        {
            placement.SetActive(false);

            this.ui_down();
            place_status = false;
            GameObject temp = Instantiate(inhand);
            temp.transform.position = inhand.transform.position;
            temp.transform.rotation = inhand.transform.rotation;
        }
    }
    public void addEntryToList(string name, float x, float y, float z)
    {
        GameObject temp = Instantiate(listItem);
        temp.transform.parent = listView.transform;
        temp.transform.GetChild(0).GetComponent<Text>().text = name;
        temp.transform.GetChild(1).GetComponent<Text>().text = "x: " + x;
        temp.transform.GetChild(2).GetComponent<Text>().text = "y: " + y;
        temp.transform.GetChild(3).GetComponent<Text>().text = "z: " + z;
        temp.transform.localScale = new Vector3(1, 1, 1);


    }
}
