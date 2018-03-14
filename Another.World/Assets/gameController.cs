using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameController:MonoBehaviour{

    public GameObject Menu;
    public bool CameraDisable =false;
    public bool MouseVisiable = false;
    public bool MenuState = false;


    void Start()
    {

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
    }

}
