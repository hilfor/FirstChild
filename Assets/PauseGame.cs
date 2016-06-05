using UnityEngine;
using System.Collections;

public class PauseGame : MonoBehaviour
{

    public void Pause()
    {
        EventBus.LevelPaused.Dispatch();
    }
}
