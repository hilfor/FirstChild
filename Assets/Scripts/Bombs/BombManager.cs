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

    public int _Score;
    public float _TimeToLive = 0f;

    protected GameObject _bombObject;

    protected Coroutine _BombTimer;

    public abstract BombType GetBombType();
    public abstract void ShowBomb();
    public abstract void HideBomb();
    public abstract void DeployBombExplosion();
    public abstract void UpdateScore(ScoreManager scoreManager);

    public abstract void OnBombTimerDone();

    void Start()
    {
        _BombTimer = StartCoroutine("BombTimer");
    }

    protected void StopTimer()
    {
        StopCoroutine(_BombTimer);
    }

    public void Bomb_OnClick(ScoreManager scoreManager)
    {
        Debug.Log("bomb clicked");
        UpdateScore(scoreManager);
        DeployBombExplosion();
        HideBomb();
    }

    IEnumerator BombTimer()
    {
        yield return new WaitForSeconds(_TimeToLive);
        OnBombTimerDone();
    }



}
