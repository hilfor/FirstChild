using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LifeManager : MonoBehaviour
{

    public GameObject _LifePrefab;
    public int _MaxLife = 3;



    private int _CurrentLife;

    public void DecreaseLife()
    {
        _CurrentLife -= 1;
    }

    void Awake()
    {
        EventBus.GameStarted.AddListener(GameStarted);
        EventBus.GamePaused.AddListener(GamePaused);
        EventBus.GameOver.AddListener(GameOver);
    }

    void FixedUpdate()
    {
        if (_CurrentLife == 0)
        {
            EventBus.GameOver.Dispatch();
        }
    }

    void GameRestarted()
    {
        GameStarted();
    }

    void GamePaused()
    {

    }

    void GameStarted()
    {
        _CurrentLife = _MaxLife;
    }

    void GameOver()
    {

    }

    void HideObjects()
    {

    }

}
