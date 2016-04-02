using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public enum MenuTypes
{
    SPLASH,
    MAIN,
    START,
    DIFFICULTY,
    PAUSE,
    GAMEOVER,
    HOWTO,
    ABOUT,
    EXIT
}

public class MenusController : MonoBehaviour
{
    //public List<BaseMenu> _Menus;
    public  BaseMenu[] _Menus;

    public MenuTypes _defaultMenu = MenuTypes.MAIN;

    private Hashtable _menusTable;
    private BaseMenu _currentDisplayedMenu;


    private Stack _menusStack;

    public void ShowDefaultMenu()
    {
        _currentDisplayedMenu = (BaseMenu)_menusTable[_defaultMenu];
        _currentDisplayedMenu.DisplayMenu();
    }

 

    public void Awake()
    {
        //base.Awake();
        EventBus.ShowMainMenu.AddListener(ShowDefaultMenu);
    }

    void Start()
    {
        _menusStack = new Stack();
        _menusTable = new Hashtable();
        for (int i = 0; i < _Menus.Length; i++)
        {
            _menusTable.Add(_Menus[i]._menuType, _Menus[i]);
        }
        ShowDefaultMenu();
    }

    public void ChangeMenu(MenuTypes menuType)
    {
        _currentDisplayedMenu.HideMenu();
        _menusStack.Push(_currentDisplayedMenu);

        _currentDisplayedMenu = (BaseMenu)_menusTable[menuType];
        _currentDisplayedMenu.DisplayMenu();
    }

    public void BackButtonPressed()
    {
        _currentDisplayedMenu.HideMenu();
        _currentDisplayedMenu= (BaseMenu)_menusStack.Pop();
        _currentDisplayedMenu.DisplayMenu();

    }






}
