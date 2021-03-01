using System;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour {
    
    private float speed = 0.02f;
    private Renderer renderer;
    private Spawner spawner;

    private void Start() {
        renderer = GetComponent<Renderer>();
        spawner = GameObject.Find("Spawner").GetComponent<Spawner>();
    }

    // We want fixed since we apply force
    private void FixedUpdate() {
        transform.position += Vector3.up * speed;

        if (!renderer.isVisible) {
            //Destroy(gameObject);
            spawner.Notify(gameObject);
            gameObject.SetActive(false);
        }
    }    
}