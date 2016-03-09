using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour
{
    public GameObject _TextObject;
    public int _CurrentScore = 0;

    private Text _Text;
    private bool _Hidden = false;

    void Awake()
    {
        EventBus.GameUnPaused.AddListener(GameUnPaused);
        EventBus.GamePaused.AddListener(GamePaused);
        EventBus.GameStarted.AddListener(GameStarted);
    }

    void Start()
    {
        _Text = _TextObject.GetComponent<Text>();
        GameStarted();
    }

    void GameOver()
    {
        HideObject();
    }

    void GamePaused()
    {
        HideObject();
    }

    void GameUnPaused()
    {
        DisplayObject();
    }

    void GameStarted()
    {
        DisplayObject();
    }

    void HideObject()
    {
        _TextObject.SetActive(false);
        _Hidden = true;
    }

    void DisplayObject()
    {
        _TextObject.SetActive(true);
        _Hidden = false;
    }

    public void UpdateScore(int score)
    {
        _CurrentScore += score;
    }

    void FixedUpdate()
    {
        if (!_Hidden)
            if (_Text)
                _Text.text = _CurrentScore.ToString();
    }
}
