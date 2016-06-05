using UnityEngine;
using System.Collections;

public class DestroyOnAnimationEnd : MonoBehaviour {

	void DestroyMe()
    {
        Destroy(gameObject);
    }
}
