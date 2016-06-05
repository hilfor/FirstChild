using UnityEngine;
using System.Collections;

public class UnPauseButton : MonoBehaviour
{

    public void UnPause()
    {
        EventBus.LevelUnPaused.Dispatch();
    }
}
