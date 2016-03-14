using UnityEngine;
using System.Collections;

public class GameMenu : BaseMenu
{

    public GameObject _GameObject;

    void Start()
    {
        _menuType = MenuTypes.START;
    }

    public override void DisplayMenu()
    {
        if (_GameObject)
        {
            _GameObject.SetActive(true);
            EventBus.LevelStarted.Dispatch();
        }
    }

    public override void HideMenu()
    {
        if (_GameObject)
        {
            _GameObject.SetActive(false);
        }
    }

}
