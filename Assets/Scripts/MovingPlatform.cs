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
        // adapt speed

        transform.position += Vector3.up * speed;

        if (!renderer.isVisible) {
            spawner.Notify(gameObject);
            gameObject.SetActive(false);
        }
    }    
}