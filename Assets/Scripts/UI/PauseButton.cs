using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PauseButton : MonoBehaviour {


    public GameObject _ButtonUIObject; 


    void Awake()
    {
        EventBus.GameStarted.AddListener(DisplayObject);
        EventBus.GameUnPaused.AddListener(DisplayObject);
    }

    public void PauseGame()
    {
        HideObject();
        EventBus.GamePaused.Dispatch();
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
