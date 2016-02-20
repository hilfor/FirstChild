using UnityEngine;

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

    protected GameObject _bombObject;

    public abstract BombType GetBombType();
    public abstract void ShowBomb();
    public abstract void HideBomb();
    public abstract void ExplodeBomb();

    public void Bomb_OnClick()
    {
        Debug.Log("bomb clicked");
    }
}
