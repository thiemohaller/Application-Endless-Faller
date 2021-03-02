using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///     TODO: maybe simply replace with `Destroy(gameObject, timeToDestruct)`
/// </summary>
public class SelfDestuct : MonoBehaviour {

    public int timeToDestruct = 3;

    // Start is called before the first frame update
    void Start() {
        StartCoroutine(SelfDestuctionAfterTime());
    }

    private IEnumerator SelfDestuctionAfterTime() {
        yield return new WaitForSeconds(timeToDestruct);
        Destroy(gameObject);
    }
}
