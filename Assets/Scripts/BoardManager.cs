using UnityEngine;

using System.Collections;
using System;

public class BoardManager : StateObject
{
    public GameObject _Anchor;
    public GameObject _BinPrefab;
    public ScoreManager _ScoreManager;
    public float _DeltaX;
    public float _DeltaY;

    public float _BombSpawnTimer = 3f;

    private bool _levelInProgress = false;

    private State _objectState = State.HIDDEN;

    ArrayList _freeBins;
    GameObject[,] _board;

    public override void Awake()
    {
        base.Awake();
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
        if (_objectState == State.HIDDEN)
            return;

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
        while (_levelInProgress)
        {
            if (_objectState != State.HIDDEN)
            {
                if (_freeBins.Count > 0)
                {
                    int randomBinIndex = UnityEngine.Random.Range(0, _freeBins.Count);
                    GameObject randomBinObject = (GameObject)_freeBins[randomBinIndex];
                    BinManager randomBinManager = randomBinObject.GetComponent<BinManager>();
                    randomBinManager.CreateBomb();
                }
            }

            yield return new WaitForSeconds(_BombSpawnTimer);
        }
    }

    public override void GameStarted()
    {
        _levelInProgress = true;
        CreateObjects();
    }

    public override void GameEnded()
    {
        _levelInProgress = false;
        HideObjects();
    }

    public override void GamePaused()
    {
        HideObjects();
    }

    public override void GameUnPaused()
    {
        throw new NotImplementedException();
    }

    void HideObjects()
    {
        _objectState = State.HIDDEN;
    }

    void ShowObjects()
    {
        _objectState = State.DISPLAYED;
    }

    void CreateObjects()
    {
        _objectState = State.DISPLAYED;
        CreateBins();
        StartCoroutine("BombSpawner");
    }

}
