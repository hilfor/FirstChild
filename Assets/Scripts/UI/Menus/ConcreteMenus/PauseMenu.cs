﻿using UnityEngine;
using System.Collections;

public class PauseMenu : BaseMenu
{

    public GameObject _MenuObject;

    void Start()
    {
        _menuType = MenuTypes.PAUSE;
    }

    public override void DisplayMenu()
    {
        if (_MenuObject)
        {
            _MenuObject.SetActive(true);
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
