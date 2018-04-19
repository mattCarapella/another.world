using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gameController : MonoBehaviour
{

    public GameObject Menu; // menu

    public bool CameraDisable = false;
    [SerializeField]
    private bool MouseVisiable;
    public bool MenuState = false;


    public GameObject worldModelSample;

    public GameObject listItem;
    public GameObject listView;

    public GameObject inhand;
    public GameObject Player;

    /*------------------Placement UI------------------------------*/

    public GameObject placement;
    public GameObject processObj; // placement object
    public bool place_status;
    public Button confirm;
    public Text ObjectName;
    public Text ObjectDes;
    public Text ObjectPrice;

    /*------------------------------------------------------------*/

    public bool ui; // A boolean variable to check if UI is up or not => display inhand object or not

    public bool interact = false; // A boolean variable to check if current user is interacting with any obj or world

    /*------------------World Description UI------------------------------*/
    public GameObject _description; // world description pannel
    public Text owner;
    public Text descriptionText;
    public Text worldName;
    /*--------------------------------------------------------*/


    private IDictionary<int, int> keymap; // a distionary to keep track

    public int env; // 0 if in Universe, 1 in world


    /*-------------------InWorld Properties Setting---------------------------*/
    private int worldId = 0;  // world which player locate

    /*------------------------------------------------------------------------*/

    /*--------------------Object Description UI-------------------------------*/

    public GameObject obj_description;
    public Button Back;
    public Text objName, X_pos, Y_pos, Z_pos;
    public Text objDes;
    public Text objPrice;


    public GameObject Inventory;
    public bool CheckInventory = false;
    int chosen = 0;
    /*------------------------------------------------------------------------*/
    void Start()
    {
        place_status = false;
        keymap = new Dictionary<int, int>();
        for (int i = 97; i < 123; i++)
        {
            keymap[i] = 0;
        }
        ui = false;
        MouseVisiable = false;

    }
    void Update()
    {
        if (Player.GetComponent<PhotonView>().isMine) {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                CameraDisable = !CameraDisable;
            }
            if (Input.GetKeyDown(KeyCode.Escape) && !processObj && !interact && !CheckInventory)
            {


                MenuState = !MenuState;
                Menu.SetActive(MenuState);
                CameraDisable = !CameraDisable;

                MouseVisiable = !MouseVisiable;
                if (MouseVisiable)
                {
                    Cursor.visible = true;
                }
                else
                {
                    Cursor.visible = false;
                }
                ui = !ui;
                if (ui)
                {
                    inhand.SetActive(false);

                }
                else
                {
                    inhand.SetActive(true);

                }
            }
            if (Input.GetKeyDown(KeyCode.I) && !processObj && !interact && !MenuState)
            {
                CheckInventory = !CheckInventory;
                Inventory.SetActive(CheckInventory);
                CameraDisable = !CameraDisable;
                MouseVisiable = !MouseVisiable;
                if (MouseVisiable)
                {
                    Cursor.visible = true;
                }
                else
                {
                    Cursor.visible = false;
                }
                if (CheckInventory)
                {
                    CameraDisable = true;
                }
                else
                {
                    CameraDisable = false;
                }
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
                if (keymap[(int)KeyCode.Q] == 1)
                {
                    processObj.transform.Rotate(Vector3.up, Time.deltaTime * 50f);
                    Debug.Log(processObj.transform.rotation);
                }
                else if (keymap[(int)KeyCode.E] == 1)
                {
                    processObj.transform.Rotate(Vector3.down, Time.deltaTime * 50f);
                }
            }
        }
    }
    public void chosenOne()
    {
        chosen = 1;
    }
    IEnumerator generateInGame(int world)
    {
        string URL = "http://ec2-18-232-184-23.compute-1.amazonaws.com/GetWorldInfo.php";
        //skybox; gound; timespeed "\n"
        //model_id; x; y; z; rx; ry; rz "\n"
        WWWForm form = new WWWForm();
        form.AddField("worldidPost", world);
        WWW www = new WWW(URL, form);
        yield return www;
        //Debug.Log(www.text);
        string response = www.text;
        string[] rows = response.Split('\n');
        string[] fcol = rows[0].Split(';');
        GameObject.Find("GenTheWorld").GetComponent<loadWorld>().attachSkyandGround(int.Parse(fcol[0]), int.Parse(fcol[1]));
        for (int i = 1;i < rows.Length;i++)
        {
            if (rows[i] != "")
            {
                string[] cols = rows[i].Split(';');
                GameObject temp = (GameObject) this.Player.GetComponent<Player>().loadedAssets[int.Parse(cols[0])];
                temp.transform.position =  new Vector3(float.Parse(cols[1]), float.Parse(cols[2]), float.Parse(cols[3]));
                temp.transform.rotation = new Quaternion(float.Parse(cols[4]), float.Parse(cols[5]), float.Parse(cols[6]),0);
                Instantiate(temp);
            }
        }
    }
    IEnumerator generateWorld()
    {
        string URL = "http://ec2-18-232-184-23.compute-1.amazonaws.com/GetUniverseInfo.php";
        WWWForm form = new WWWForm();
        form.AddField("idPost", Login.send_id);
        WWW www = new WWW(URL, form);
        //Debug.Log(URL);
        yield return www;
        string response = www.text;
        //Debug.Log(response);
        string[] rows = response.Split('\n');

        foreach (string row in rows)
        {
            if (row != "")
            {
                //Debug.Log(row);
                string[] cols = row.Split(';');
                //Debug.Log(cols[0]);
                int worldId = int.Parse(cols[0]);
                //Debug.Log(worldId);
                int userId = int.Parse(cols[1]);
                string username = cols[2];
                string title = cols[3];
                string description = cols[4];
                float x = float.Parse(cols[5]);
                float y = float.Parse(cols[6]);
                float z = float.Parse(cols[7]);

                //Debug.Log(x);
                GameObject temp = Instantiate(worldModelSample);
                temp.GetComponent<planet>()._game = this.gameObject;
                temp.transform.position = new Vector3(x, y, z);
                planet sample = temp.GetComponent<planet>();

                sample.setDes(description);
                sample.setId(worldId);
                sample.setOwner(username);
                sample.setName(title);
                addEntryToList(title, x, y, z);

            }


        }
    }
    public void ui_up()
    {
        CameraDisable = true;
        MouseVisiable = true;
        Cursor.visible = true;
    }

    public void ui_down()
    {
        CameraDisable = false;
        MouseVisiable = false;
        Cursor.visible = false;
    }

    public void place()
    {

        //Debug.Log(place_status);
        confirm.interactable = true;
        if (place_status == false)
        {
            placement.SetActive(true);
            this.ui_up();
            place_status = true;
            interact = false;
        }
    }
    public void place_request()
    {
        //Debug.Log(place_status);
        if (place_status == true)
        {

            placement.SetActive(false);

            this.ui_down();

            place_status = false;
            Player.GetComponent<PlayerController>().SpawnObject();

            processObj = null;
            /*GameObject temp = Instantiate(inhand);
            temp.transform.SetParent(_assetHolder.transform);
            temp.transform.position = inhand.transform.position;
            temp.transform.rotation = inhand.transform.rotation;
            */

        }
    }
    public void attachObjAttr(GameObject obj)
    {
        obj.GetComponent<object_property>().setDescription(ObjectDes.text);
        obj.GetComponent<object_property>().setName(ObjectName.text);
        obj.GetComponent<object_property>().setPrice(ObjectPrice.text);
        StartCoroutine(addObjToDB(inhand));
        obj.AddComponent<BoxCollider>();
    }
    public void post()
    {
        StartCoroutine(addObjToDB(inhand));
    }

    IEnumerator addObjToDB(GameObject inhand)
    {
        WWWForm form = new WWWForm();
        form.AddField("worldidPost", PhotonNetworkManager.world);
        form.AddField("modelidPost", Player.GetComponent<Player>().getSeleted());
        form.AddField("modelxPost", inhand.transform.position.x.ToString());
        form.AddField("modelyPost", inhand.transform.position.y.ToString());
        form.AddField("modelzPost", inhand.transform.position.z.ToString());
        form.AddField("rotationxPost", inhand.transform.rotation.x.ToString());
        form.AddField("rotationyPost", inhand.transform.rotation.y.ToString());
        form.AddField("rotationzPost", inhand.transform.rotation.z.ToString());
        string url = "http://ec2-18-232-184-23.compute-1.amazonaws.com/AddObjects.php";
        WWW www = new WWW(url, form);
        yield return www;
        //Debug.Log(www.text);
    }
    public void addEntryToList(string name, float x, float y, float z)
    {
        GameObject temp = Instantiate(listItem);
        temp.transform.SetParent(listView.transform);
        temp.transform.GetChild(0).GetComponent<Text>().text = name;
        temp.transform.GetChild(1).GetComponent<Text>().text = "x: " + x;
        temp.transform.GetChild(2).GetComponent<Text>().text = "y: " + y;
        temp.transform.GetChild(3).GetComponent<Text>().text = "z: " + z;
        temp.transform.localScale = new Vector3(1, 1, 1);
        temp.transform.rotation.Set(0, 0, 0, 0);


    }
    public void ui_off(GameObject UI)
    {
        UI.SetActive(false);
        ui = false;
        if (ui)
        {
            inhand.SetActive(false);
        }
        else
        {
            inhand.SetActive(true);
            ui_down();
        }

    }
    public void menu_off()
    {

        MenuState = false;
    }
    public void inv_off()
    {
        CheckInventory = false;
    }
    public static void loadScene(int idx)
    {
        SceneManager.LoadScene(idx);
    }
    public void exit()
    {
        Application.Quit();
    }
    public void reloadWorld(int value)
    {
        env = value;
        if (env == 0)
        {
            StartCoroutine(generateWorld());
        }
        else
        {
            StartCoroutine(generateInGame(PhotonNetworkManager.world));
        }
        Player.GetComponent<PlayerController>().reset();
    }
    public void interact_off()
    {
        interact = false;
    }
    public void disconnect()
    {
        AssetBundle.UnloadAllAssetBundles(true);
        PhotonNetwork.Disconnect();
    }
    public void changeWorld(int idx)
    {
        PhotonNetworkManager.world = idx;
    }
}
