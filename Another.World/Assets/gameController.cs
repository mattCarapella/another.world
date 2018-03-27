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
    private IDictionary<int, int> keymap;
    

    void Start()
    {
        place_status = false;
        keymap = new Dictionary<int, int>();
        for (int i=97;i<123;i++)
        {
            keymap[i] = 0;
        }
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
}
