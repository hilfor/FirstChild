using UnityEngine;
using System.Collections;


public enum State
{
    NEW,
    PAUSED,
    DISPLAYED
}
public abstract class StateObject : MonoBehaviour
{

    

    public virtual void Awake()
    {
        EventBus.GameOver.AddListener(GameEnded);
        EventBus.LevelStarted.AddListener(GameStarted);
        EventBus.LevelPaused.AddListener(GamePaused);
        EventBus.LevelUnPaused.AddListener(GameUnPaused);
    }

    public abstract void GameStarted();
    public abstract void GameEnded();
    public abstract void GamePaused();
    public abstract void GameUnPaused();


}
