using UnityEngine;
using System.Collections;
using System;

public enum BombType
{
    PEE,
    POOP,
    BABY_BOY,
    BABY_GIRL
}

public enum BombStatus
{
    ACTIVATED,
    DEACTIVATED,
    EXPLODED,
    DUD
}

public abstract class BombManager : MonoBehaviour
{
    public BombType _BombType;
    public BombStatus _BombStatus;
    public GameObject _BombDestroyAnimation;
    public ScoreManager _ScoreManager;
    public LifeManager _LifeManager;
    public int _Score;
    public float _TimeToLive = 0f;

    protected GameObject _bombObject;

    protected Coroutine _BombTimer;

    public Animator _Animator;

    public abstract BombType GetBombType();
    public abstract void ShowBomb();


    public void DeployBombExplosion()
    {
        if (_Animator)
            _Animator.SetTrigger("Hit");
        if (_BombDestroyAnimation)
            Instantiate(_BombDestroyAnimation, transform.position, Quaternion.identity);
    }

    public abstract void UpdateScore(int score);

    public abstract void OnBombTimerDone();
    public abstract void BombClicked();
    void Start()
    {
        _BombTimer = StartCoroutine("BombTimer");
        _Animator = GetComponentInChildren<Animator>();
        EventBus.LevelPaused.AddListener(LevelPaused);
        EventBus.LevelUnPaused.AddListener(LevelUnPaused);
    }

    private void LevelUnPaused()
    {
        _BombTimer = StartCoroutine("BombTimer");
    }

    private void LevelPaused()
    {
        StopCoroutine(_BombTimer);
    }

    protected void StopTimer()
    {
        StopCoroutine(_BombTimer);
    }

    public void Bomb_OnClick()
    {
        StopTimer();
        DeployBombExplosion();
        BombClicked();
    }

    IEnumerator BombTimer()
    {
        while (_TimeToLive > 0)
        {
            yield return new WaitForEndOfFrame();
            _TimeToLive -= Time.deltaTime;
        }
        OnBombTimerDone();
    }



}
