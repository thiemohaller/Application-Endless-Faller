using UnityEngine;

public class MovingPlatform : MonoBehaviour {
    
    private float speed = 0.02f;

    // We want fixed since we apply force
    private void FixedUpdate() {
        // adapt speed
        transform.position += Vector3.up * speed;
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Bounds")) {
            Destroy(this);
        }
    }
}