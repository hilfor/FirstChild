using UnityEngine;
using System.Collections;

public class GameMenu : BaseMenu
{

    public BoardManager _boardManager;
    public GameObject _UI;

    void Start()
    {
        _menuType = MenuTypes.START;
    }

    public override void DisplayMenu()
    {
        if (_boardManager)
        {
            if (_boardManager._objectState == State.NEW)
            {
                EventBus.LevelStarted.Dispatch();
            }
            else
            {
                EventBus.LevelUnPaused.Dispatch();
            }
            _UI.SetActive(true);
            //_GameObject.SetActive(true);
        }
    }

    public override void HideMenu()
    {
        if (_boardManager)
        {
            if (_boardManager._objectState == State.DISPLAYED)
            {
                EventBus.LevelPaused.Dispatch();
            }
            else
            {
                EventBus.GameOver.Dispatch();
            }
            _UI.SetActive(false);
            //_GameObject.SetActive(false);
        }
    }

}
