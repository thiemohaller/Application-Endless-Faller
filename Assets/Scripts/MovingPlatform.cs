using UnityEngine;

public class MovingPlatform : MonoBehaviour {
    
    public float Speed { get; set; }

    // We want fixed since we apply force
    private void FixedUpdate() {
        // adapt speed
        transform.position += Vector3.up * Speed;
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Bounds")) {
            Destroy(this);
        }
    }
}