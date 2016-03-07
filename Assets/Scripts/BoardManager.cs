using UnityEngine;
using System.Collections;

public class BoardManager : MonoBehaviour
{
    public GameObject _Anchor;
    public GameObject _BinPrefab;
    public ScoreManager _ScoreManager;
    public float _DeltaX;
    public float _DeltaY;

    public float _BombSpawnTimer = 3f;


    ArrayList _freeBins;
    GameObject[,] _board;

    void Awake()
    {
        EventBus.BinCleared.AddListener(BinCleared);
    }

    void BinCleared(GameObject clearedBin)
    {
        _freeBins.Add(clearedBin);
    }

    // Use this for initialization
    void Start()
    {
        CreateBins();
        StartCoroutine("BombSpawner");
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D _hit = new RaycastHit2D();
        if (Input.touchCount > 0)
        {
            _hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position), Vector3.forward, 100f);
            Debug.DrawRay(Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position), Vector3.forward);
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                _hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector3.forward, 100f);
                Debug.DrawRay(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector3.forward);
            }
        }

        if (_hit.collider)
        {
            _hit.collider.GetComponent<BinManager>().Bin_Onclick();
        }
    }

    void CreateBins()
    {
        _freeBins = new ArrayList();
        _board = new GameObject[4, 4];
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                _board[i, j] = (GameObject)Instantiate(_BinPrefab, _Anchor.transform.position + new Vector3(i * _DeltaX, j * _DeltaY, 0), Quaternion.identity);
                _freeBins.Add(_board[i, j]);
                SetBinMembers(_board[i, j].GetComponent<BinManager>());
            }
        }
    }

    void SetBinMembers(BinManager bin)
    {
        bin._ScoreManager = _ScoreManager;
    }

    IEnumerator BombSpawner()
    {
        while (true)
        {
            if (_freeBins.Count > 0)
            {
                int randomBinIndex = Random.Range(0, _freeBins.Count);
                GameObject randomBinObject = (GameObject)_freeBins[randomBinIndex];
                BinManager randomBinManager = randomBinObject.GetComponent<BinManager>();
                randomBinManager.CreateBomb();
            }

            yield return new WaitForSeconds(_BombSpawnTimer);
        }
    }
}
