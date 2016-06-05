using UnityEngine;
using System.Collections;


public class BinManager : MonoBehaviour
{
    //public GameObject[] _BombsPrefabList;
    public GameObject _PeeBomb;
    public GameObject _PoopBomb;
    public GameObject _BabyBoyBomb;
    public GameObject _BabyGirlBomb;
    public ScoreManager _ScoreManager;
    public LifeManager _LifeManager;

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
        _bombsTypeHash.Add(BombType.BABY_BOY, _BabyBoyBomb);
        _bombsTypeHash.Add(BombType.BABY_GIRL, _BabyGirlBomb);
    }

    public void CreateBomb()
    {
        if (IsEmpty)
        {
            int randomBombType = Random.Range(0, sizeof(BombType) * 1000) % 4;
            CreateBombByType((BombType)randomBombType);
            _empty = false;
        }
    }

    void CreateBombByType(BombType bombType)
    {
        _binBomb = (GameObject)Instantiate((GameObject)_bombsTypeHash[bombType], transform.position - new Vector3(0, 0, 1), Quaternion.identity);
        _binBomb.transform.parent = transform;
        _binBomb.GetComponent<BombManager>()._ScoreManager = _ScoreManager;
        _binBomb.GetComponent<BombManager>()._LifeManager = _LifeManager;
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

        _empty = true;
        EventBus.BinCleared.Dispatch(gameObject);

    }

}
