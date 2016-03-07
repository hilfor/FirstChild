using UnityEngine;
using System.Collections;

public class DestroyAfterSeconds : MonoBehaviour {
    public float _SecondsToLive = 0;

    void Start()
    {
        Destroy(gameObject, _SecondsToLive);
    }
}
