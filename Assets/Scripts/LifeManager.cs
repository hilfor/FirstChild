﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LifeManager : MonoBehaviour
{

    //public GameObject _LifePrefab;
    //[Header("Done set the above prefab")]
    public GameObject _LifeObject;
    public GameObject _LifeLayoutParent;
    public GameObject _LifeSprite;

    public int _MaxLife = 3;

    private bool _hidden = false;

    //private Text _lifeText;
    private int _currentLife;

    public void DecreaseLife()
    {
        _currentLife -= 1;
    }

    void Awake()
    {
        EventBus.LevelStarted.AddListener(GameStarted);
        EventBus.LevelPaused.AddListener(GamePaused);
        EventBus.GameOver.AddListener(GameOver);
    }

    void Start()
    {
        //_lifeText = _LifeObject.GetComponent<Text>();

        GameStarted();
    }

    void FixedUpdate()
    {
        if (!_hidden)
        {
            //_lifeText.text = _currentLife.ToString();
            if (_currentLife == 0)
                EventBus.GameOver.Dispatch();
        }
    }

    void GameRestarted()
    {
        GameStarted();
    }

    void GamePaused()
    {
        HideObjects();
    }

    void GameStarted()
    {
        for (int i = 0; i < _MaxLife; i++)
        {
            GameObject go = (GameObject)Instantiate(_LifeSprite, _LifeLayoutParent.transform.position, Quaternion.identity);
            go.transform.SetParent(_LifeLayoutParent.transform);
            go.transform.localScale = Vector3.one;
        }
        _currentLife = _MaxLife;
        _hidden = false;
        DisplayObjects();
    }

    void GameOver()
    {
        HideObjects();
    }

    void HideObjects()
    {
        _LifeObject.SetActive(false);
    }

    void DisplayObjects()
    {
        _LifeObject.SetActive(true);
    }

}
