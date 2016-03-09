using UnityEngine;

public static class EventBus
{
    public static Signal<GameObject> BinCleared = new Signal<GameObject>();
    public static Signal GameOver = new Signal();
    public static Signal GamePaused = new Signal();
    public static Signal GameStarted = new Signal();
    public static Signal GameUnPaused = new Signal();



}
