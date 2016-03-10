using UnityEngine;
using System.Collections;

public abstract class StateObject : MonoBehaviour
{

    public enum State
    {
        HIDDEN,
        DISPLAYED
    }

    public void Awake()
    {
        EventBus.GameOver.AddListener(GameEnded);
        EventBus.GameStarted.AddListener(GameStarted);
        EventBus.GamePaused.AddListener(GamePaused);
        EventBus.GameUnPaused.AddListener(GameUnPaused);
    }

    public abstract void GameStarted();
    public abstract void GameEnded();
    public abstract void GamePaused();
    public abstract void GameUnPaused();


}
