using UnityEngine;

public class MovingPlatform : MonoBehaviour {
    
    public float Speed { get; set; }

    private void FixedUpdate() {
        // adapt speed
        transform.position += Vector3.up * Speed;
    }
}