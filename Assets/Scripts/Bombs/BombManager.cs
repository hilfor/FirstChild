using UnityEngine;
using System.Collections;

public enum BombType
{
    PEE,
    POOP,
    BABY
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
    


    void Start()
    {
        _BombTimer = StartCoroutine("BombTimer");
        _Animator = GetComponent<Animator>();
    }

    protected void StopTimer()
    {
        StopCoroutine(_BombTimer);
    }

    public void Bomb_OnClick()
    {
        StopTimer();
        DeployBombExplosion();
        UpdateScore(_Score);
        //HideBomb();
    }

    IEnumerator BombTimer()
    {
        yield return new WaitForSeconds(_TimeToLive);
        OnBombTimerDone();
    }



}
