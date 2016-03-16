using UnityEngine;
using System.Collections;
using System;

public enum MenuTypes
{
    MAIN_MENU,
    START,
    CREDITS,
    QUIT,
    PAUSE
}

public class MenusController : MonoBehaviour
{
    public BaseMenu[] _Menus;

    private Hashtable _menusTable;
    private BaseMenu _currentDisplayedMenu;

    private Stack _menusStack;

    public void ShowMainMenu()
    {
        _currentDisplayedMenu = (BaseMenu)_menusTable[MenuTypes.MAIN_MENU];
        _currentDisplayedMenu.DisplayMenu();
    }

 

    public void Awake()
    {
        //base.Awake();
        EventBus.ShowMainMenu.AddListener(ShowMainMenu);
    }

    void Start()
    {
        _menusStack = new Stack();
        _menusTable = new Hashtable();
        for (int i = 0; i < _Menus.Length; i++)
        {
            _menusTable.Add(_Menus[i]._menuType, _Menus[i]);
        }
        ShowMainMenu();
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
