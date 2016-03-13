using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PauseButton : MonoBehaviour {


    public GameObject _ButtonUIObject; 


    void Awake()
    {
        EventBus.LevelStarted.AddListener(DisplayObject);
        EventBus.LevelUnPaused.AddListener(DisplayObject);
    }

    public void PauseGame()
    {
        HideObject();
        EventBus.LevelPaused.Dispatch();
    }

    void DisplayObject()
    {
        _ButtonUIObject.SetActive(true);
    }

    void HideObject()
    {
        _ButtonUIObject.SetActive(false);

    }
}
