using UnityEngine;
using System.Collections;

public class BoardManager : MonoBehaviour {

    public GameObject _Anchor;
    public GameObject _BinPrefab;
    public float _DeltaX;
    public float _DeltaY;

    GameObject[,] _board;

    // Use this for initialization
    void Start()
    {
        _board = new GameObject[4, 4];
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                Instantiate(_BinPrefab, _Anchor.transform.position + new Vector3(i * _DeltaX, j * _DeltaY, 0), Quaternion.identity);
            }
        }

    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
