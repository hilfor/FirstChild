using UnityEngine;
using System.Collections;


public class BinManager : MonoBehaviour
{
    //public GameObject[] _BombsPrefabList;
    public GameObject _PeeBomb;
    public GameObject _PoopBomb;
    public GameObject _BabyBomb;
    public ScoreManager _ScoreManager;


    private GameObject _binBomb;
    private Hashtable _bombsTypeHash;
    private bool _empty = true;
    //private bool _destroySequenceActive = false;
    public bool IsEmpty
    {
        get
        {
            return _empty;
        }
    }

    void Awake()
    {
        CreateBombTypesHashtable();
    }

    void CreateBombTypesHashtable()
    {
        _bombsTypeHash = new Hashtable();
        _bombsTypeHash.Add(BombType.PEE, _PeeBomb);
        _bombsTypeHash.Add(BombType.POOP, _PoopBomb);
        _bombsTypeHash.Add(BombType.BABY, _BabyBomb);
    }

    public void CreateBomb()
    {
        int randomBombType = Random.Range(0, sizeof(BombType) * 1000) % 3;
        CreateBombByType((BombType)randomBombType);
        _empty = false;
    }

    void CreateBombByType(BombType bombType)
    {
        _binBomb = (GameObject)Instantiate((GameObject)_bombsTypeHash[bombType], transform.position, Quaternion.identity);
        _binBomb.transform.parent = transform;
        _binBomb.GetComponent<BombManager>()._ScoreManager = _ScoreManager;
    }


    public void Bin_Onclick()
    {
        if (!_empty)
        {
            BombDestroySequence();
        }
    }

    void BombDestroySequence()
    {
        BombManager bombManager = _binBomb.GetComponent<BombManager>();
        bombManager.Bomb_OnClick();

        //GameObject bombDestroyAnimation = _binBomb.GetComponent<BombManager>()._BombDestroyAnimation;

        //if (bombDestroyAnimation)
        //{
        //    Instantiate(bombDestroyAnimation, _binBomb.transform.position, Quaternion.identity);
        //}

        //Destroy(_binBomb);
        _empty = true;
        EventBus.BinCleared.Dispatch(gameObject);

    }

}
