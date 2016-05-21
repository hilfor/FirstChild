using UnityEngine;
using System.Collections;

public class ExecuteDelayedFunction : MonoBehaviour {

    public float delay = 3f;
    public FluxAnimation flux;

    void Start()
    {
        StartCoroutine("ClosingAnim");
    }

    IEnumerator ClosingAnim() {
        yield return new WaitForSeconds(delay);
        flux.StartClosingAnimation();
    }


}
