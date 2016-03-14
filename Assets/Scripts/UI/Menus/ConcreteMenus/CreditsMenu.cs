using UnityEngine;
using System.Collections;
using System;

public class CreditsMenu : BaseMenu {

    public GameObject _MenuObject;

    void Start()
    {
        _menuType = MenuTypes.CREDITS;
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
