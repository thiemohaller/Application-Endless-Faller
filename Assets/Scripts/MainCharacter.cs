using Assets.Scripts;
using UnityEngine;

public class MainCharacter : MonoBehaviour {

    public new Rigidbody rigidbody;
    public float swerveForce = 5f;
    [Range(1, 10)]
    public int playerSpeedMultiplier = 2;
    
    // Let the player float for the first 3 seconds in order to spawn platforms
    private float playerWait = 3.0f;
    private float timePassed;
    private LevelManager lvlManager;

    // Lock rotation so that the player doesn't tumble, using Awake since we do not need any other objects
    private void Awake() {
        rigidbody.freezeRotation = true;
        rigidbody.useGravity = false;
        timePassed = 0.0f;
    }

    private void Start() {
        lvlManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
    }

    // Since we apply force, we want `FixedUpdate` to keep it consistant    
    void FixedUpdate() {
        timePassed += Time.deltaTime;
        if (timePassed < playerWait) {
            return;
        }
        rigidbody.useGravity = true;

        // Movement
        float xPosition = Input.GetAxis("Horizontal") * Time.fixedDeltaTime * swerveForce * playerSpeedMultiplier;
        Vector3 newPosition = rigidbody.position + Vector3.right * xPosition;
        rigidbody.MovePosition(newPosition);
    }

    /// <summary>
    ///     This method is used to end the game if the player gets out of bounds
    /// </summary>
    /// <param name="other">Collider which is used to detect if it was a boundary block</param>
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Bounds")) {
            Debug.Log("Touched bounds");
            // game over
        }        
    }

    /// <summary>
    ///     This method is used to tally the scores
    /// </summary>
    /// <param name="other">Collider which is used to detect if it was a score block</param>
    private void OnTriggerExit(Collider other) {
        if (other.gameObject.CompareTag("Score")) {
            Debug.Log("Scored");
            Destroy(other.gameObject);
            lvlManager.IncrementScore();
        }
    }
}
