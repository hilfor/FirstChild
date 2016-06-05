using UnityEngine;

using System.Collections;
using System;


public class BoardManager : MonoBehaviour
{
    public GameObject _Anchor;
    public GameObject _BinPrefab;
    public ScoreManager _ScoreManager;
    public LifeManager _LifeManager;
    public float _DeltaX;
    public float _DeltaY;

    public int _boardSizeX = 3;
    public int _boardSizeY = 3;

    public float _BombSpawnTimer = 3f;

    public State _objectState = State.NEW;

    private bool _levelInProgress = false;

    private Coroutine _spawnerCoroutine = null;

    ArrayList _freeBins;
    GameObject[,] _board;

    void Awake()
    {
        RegisterHandlers();
        LevelStarted();
    }

    void RegisterHandlers()
    {
        EventBus.BinCleared.AddListener(BinCleared);
        EventBus.LevelStarted.AddListener(LevelStarted);
        EventBus.LevelPaused.AddListener(LevelPaused);
        EventBus.LevelUnPaused.AddListener(LevelUnPaused);
        EventBus.GameOver.AddListener(LevelEnded);
    }
    void LevelStarted()
    {
        //init boardSize and recreate bins only if it is a new game
        if (_objectState == State.NEW)
        {
            if (PlayerPrefs.HasKey("boardSizeX"))
                _boardSizeX = PlayerPrefs.GetInt("boardSizeX");
            if (PlayerPrefs.HasKey("boardSizeY"))
                _boardSizeY = PlayerPrefs.GetInt("boardSizeY");
            if (PlayerPrefs.HasKey("spawnTimer"))
                _BombSpawnTimer = PlayerPrefs.GetFloat("spawnTimer");

            CreateBins();
        }
        _levelInProgress = true;

        _objectState = State.DISPLAYED;
        _spawnerCoroutine = StartCoroutine("BombSpawner");
    }

    void LevelPaused()
    {
        // hide bins
        EnableBins(false);
        _objectState = State.PAUSED;
    }

    void LevelUnPaused()
    {
        // unhide bins
        EnableBins(true);
        _objectState = State.DISPLAYED;
    }


    void LevelEnded()
    {
        // delete bins
        if (_spawnerCoroutine != null)
        {
            _levelInProgress = false;
            StopCoroutine(_spawnerCoroutine);
            _spawnerCoroutine = null;
        }
    }
    void BinCleared(GameObject clearedBin)
    {
        _freeBins.Add(clearedBin);
    }

    // Update is called once per frame
    void Update()
    {
        if (_objectState != State.DISPLAYED)
            return;

        RaycastHit2D _hit = new RaycastHit2D();
        if (Input.touchCount > 0)
        {
            _hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position), Vector3.forward, 100f);
            //Debug.DrawRay(Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position), Vector3.forward);
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                _hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector3.forward, 100f);
                //Debug.DrawRay(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector3.forward);
            }
        }

        if (_hit.collider)
        {
            Debug.Log("Hit " + _hit.collider.tag);
            if (_hit.collider.GetComponent<BinManager>())
                _hit.collider.GetComponent<BinManager>().Bin_Onclick();

        }
    }

    void CreateBins()
    {
        _freeBins = new ArrayList();
        _board = new GameObject[4, 4];
        for (int i = 0; i < _boardSizeX; i++)
        {
            for (int j = 0; j < _boardSizeY; j++)
            {
                _board[i, j] = (GameObject)Instantiate(_BinPrefab, _Anchor.transform.position + new Vector3(i * _DeltaX, j * _DeltaY, 0), Quaternion.identity);
                _board[i, j].transform.parent = _Anchor.transform;
                _freeBins.Add(_board[i, j]);
                SetBinMembers(_board[i, j].GetComponent<BinManager>());
            }
        }
    }

    void SetBinMembers(BinManager bin)
    {
        bin._ScoreManager = _ScoreManager;
        bin._LifeManager = _LifeManager;
    }

    IEnumerator BombSpawner()
    {
        while (_levelInProgress)
        {
            if (_objectState != State.PAUSED)
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

    void EnableBins(bool binsState)
    {
        for (int i = 0; i < _boardSizeX; i++)
        {
            for (int j = 0; j < _boardSizeY; j++)
            {
                _board[i, j].SetActive(binsState);
            }
        }
    }
}
