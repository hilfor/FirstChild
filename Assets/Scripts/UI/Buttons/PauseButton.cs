using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class PauseButton : BaseButton
{

    public GameObject _ButtonGraphic;

    void Awake()
    {

        EventBus.LevelPaused.AddListener(LevelPaused);
        EventBus.LevelUnPaused.AddListener(LevelUnPaused);

    }

    public void PauseGame()
    {
        EventBus.LevelPaused.Dispatch();
    }

    void LevelPaused()
    {
        if (_ButtonGraphic)
            _ButtonGraphic.SetActive(false);
    }

    void LevelUnPaused()
    {
        if (_ButtonGraphic)
            _ButtonGraphic.SetActive(true);
    }

    public override void ButtonPressed()
    {
        EventBus.LevelPaused.Dispatch();
        _menu.ChangeMenu(MenuTypes.PAUSE);
    }
}
