using UnityEngine;

using System.Collections;
using System;

public class BoardManager : MonoBehaviour
{
    public GameObject _Anchor;
    public GameObject _BinPrefab;
    public ScoreManager _ScoreManager;
    public float _DeltaX;
    public float _DeltaY;

    public float _BombSpawnTimer = 3f;

    private bool _levelInProgress = false;

    private State _objectState = State.PAUSED;
    private Coroutine _spawnerCoroutine = null;

    ArrayList _freeBins;
    GameObject[,] _board;

    //public override void Awake()
    //{
    //    base.Awake();
    //    EventBus.BinCleared.AddListener(BinCleared);
    //    EventBus.LevelStarted.AddListener(LevelStarted);
    //}

    void Awake()
    {
        RegisterHandlers();
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
        CreateBins();
        _objectState = State.DISPLAYED;
        _spawnerCoroutine = StartCoroutine("BombSpawner");
    }

    void LevelPaused()
    {
        _objectState = State.PAUSED;
    }

    void LevelUnPaused()
    {
        _objectState = State.DISPLAYED;
    }

    void LevelEnded()
    {
        if (_spawnerCoroutine != null)
        {
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
        if (_objectState == State.PAUSED)
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

    //public override void GameStarted()
    //{
    //    _levelInProgress = true;
    //    CreateObjects();
    //}

    //public override void GameEnded()
    //{
    //    _levelInProgress = false;
    //    HideObjects();
    //}

    //public override void GamePaused()
    //{
    //    HideObjects();
    //}

    //public override void GameUnPaused()
    //{
    //    throw new NotImplementedException();
    //}



    //void CreateObjects()
    //{
    //    _objectState = State.DISPLAYED;
    //    CreateBins();
    //    StartCoroutine("BombSpawner");
    //}

}
