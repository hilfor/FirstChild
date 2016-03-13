using UnityEngine;
using System.Collections;


/*
    This class controlls the whole game flow (including the game states, paused/running/stopped-menu display )
*/

public enum GameState
{
    SHOW_MENU,
    LEVEL_STARTED,
    LEVEL_PAUSED,
    LEVEL_UNPAUSED,
    GAME_OVER,
    DISPLAY_SCORES
}

public class GameController : MonoBehaviour {

    void Awake()
    {

    }

    void Start()
    {

    }

}
