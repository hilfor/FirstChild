using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class LifeManager : MonoBehaviour
{
    public GameObject _LifeObject;
    public GameObject _LifeLayoutParent;
    public GameObject _LifeSprite;

    public int _MaxLife = 3;

    private bool _hidden = false;

    private int _currentLife;
    private List<GameObject> _heartsList;


    public void DecreaseLife()
    {
        _heartsList[_currentLife - 1].GetComponent<Animator>().SetTrigger("Hide");
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
        _heartsList = new List<GameObject>();
        GameStarted();
    }

    void FixedUpdate()
    {
        if (!_hidden)
        {
            if (_currentLife == 0)
                EventBus.GameOver.Dispatch();
        }
    }

    void GameRestarted()
    {
        DisplayObjects();
        for (int i = 0; i < _heartsList.Count; i++)
        {
            _heartsList[i].GetComponent<Animator>().SetTrigger("restart");
        }
        _currentLife = _MaxLife;
        _hidden = false;
    }

    void GamePaused()
    {
        HideObjects();
    }

    void GameStarted()
    {
        for (int i = 0; i < _MaxLife; i++)
        {
            GameObject heart = (GameObject)Instantiate(_LifeSprite, _LifeLayoutParent.transform.position, Quaternion.identity);
            heart.transform.SetParent(_LifeLayoutParent.transform);
            heart.transform.localScale = Vector3.one;
            _heartsList.Add(heart);
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
        _hidden = true;
        _LifeObject.SetActive(false);
    }

    void DisplayObjects()
    {
        _hidden = false;
        _LifeObject.SetActive(true);
    }

}
