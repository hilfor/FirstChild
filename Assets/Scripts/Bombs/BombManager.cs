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
    public GameObject _BombPrefab;
    public GameObject _BombDestroyAnimation;
    public ScoreManager _ScoreManager;
    public int _Score;
    public float _TimeToLive = 0f;

    protected GameObject _bombObject;

    protected Coroutine _BombTimer;

    public abstract BombType GetBombType();
    public abstract void ShowBomb();

    public void HideBomb()
    {
        Destroy(gameObject);
    }

    public void DeployBombExplosion()
    {
        if (_BombDestroyAnimation)
            Instantiate(_BombDestroyAnimation, transform.position, Quaternion.identity);
    }

    public void UpdateScore(int score)
    {
        _ScoreManager.UpdateScore(score);

    }

    public void OnBombTimerDone()
    {
        UpdateScore(-_Score);
        HideBomb();
    }

    void Start()
    {
        _BombTimer = StartCoroutine("BombTimer");
    }

    protected void StopTimer()
    {
        StopCoroutine(_BombTimer);
    }

    public void Bomb_OnClick()
    {
        Debug.Log("bomb clicked");
        UpdateScore(_Score);
        DeployBombExplosion();
        HideBomb();
    }

    IEnumerator BombTimer()
    {
        yield return new WaitForSeconds(_TimeToLive);
        OnBombTimerDone();
    }



}
