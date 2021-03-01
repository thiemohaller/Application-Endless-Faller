using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacter : MonoBehaviour {

    public new Rigidbody rigidbody;
    public float swerveForce = 5f;
    [Range(1, 10)]
    public int playerSpeedMultiplier = 2;

    // Lock rotation so that the player doesn't tumble, using Awake since we do not need any other objects
    private void Awake() {
        rigidbody.freezeRotation = true;
    }

    // Since we apply force, we want `FixedUpdate` to keep it consistant
    void FixedUpdate() {
        float xPosition = Input.GetAxis("Horizontal") * Time.fixedDeltaTime * swerveForce * playerSpeedMultiplier;
        Vector3 newPosition = rigidbody.position + Vector3.right * xPosition;
        // possible TODO: clamp movement
        rigidbody.MovePosition(newPosition);
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "Bounds") {
            // game over
        }

        if (collision.gameObject.tag == "Score") {
            // increase points
        }
    }
}
