using UnityEngine;
using System.Collections;


public class BinManager : MonoBehaviour
{
    //public GameObject[] _BombsPrefabList;
    public GameObject _PeeBomb;
    public GameObject _PoopBomb;
    public GameObject _BabyBomb;


    private GameObject _binBomb;
    private Hashtable _bombsTypeHash;
    private bool _empty = true;
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
        int randomBombType = Random.Range(0, sizeof(BombType)*1000 )%3;
        CreateBombByType((BombType)randomBombType);
        _empty = false;
    }

    void CreateBombByType(BombType bombType)
    {
        _binBomb = (GameObject)Instantiate((GameObject)_bombsTypeHash[bombType], transform.position, Quaternion.identity);
    }


    public void Bin_Onclick()
    {
        if (!_empty)
        {

        }
    }

}
