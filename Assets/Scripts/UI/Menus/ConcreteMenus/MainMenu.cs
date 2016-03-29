using UnityEngine;
using System;
using System.Collections;
[Serializable]
public class MainMenu : BaseMenu
{

    public GameObject _MenuObject;

    void Start()
    {
        _menuType = MenuTypes.MAIN_MENU;
    }

    public override void DisplayMenu()
    {
        if (_MenuObject)
        {
            _MenuObject.SetActive(true);
            //EventBus.LevelStarted.Dispatch();
        }
    }

    public override void HideMenu()
    {
        if (_MenuObject)
        {
            _MenuObject.SetActive(false);
        }
    }

}
