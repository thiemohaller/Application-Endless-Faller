using Assets.Scripts;
using UnityEngine;

public class MainCharacter : MonoBehaviour {

    public new Rigidbody rigidbody;
    [Range(1, 30)]
    public int playerSpeed = 10;
    public LevelManager lvlManager;
        
    private Movement Movement;
    
    // Lock rotation so that the player doesn't tumble, using Awake since we do not need any other objects
    private void Awake() {
        rigidbody.freezeRotation = true;
    }

    private void Start() {
        Movement = gameObject.AddComponent<Movement>();
        Movement.PlayerSpeed = playerSpeed;
    }

    // Since we apply force, we want `FixedUpdate` to keep it consistant    
    void FixedUpdate() {
        // Movement
        var calculatedNewPosition = Movement.Calculate(
            Input.GetAxisRaw("Horizontal"), 
            Time.deltaTime);

        rigidbody.MovePosition(rigidbody.position + calculatedNewPosition);
    }

    /// <summary>
    ///     This method is used to end the game if the player gets out of bounds
    /// </summary>
    /// <param name="other">Collider which is used to detect if it was a boundary block</param>
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Bounds")) {
            lvlManager.GameOver();
        }        
    }

    /// <summary>
    ///     This method is used to tally the scores, I chose exit since it makes it harder to run into erronous detection
    /// </summary>
    /// <param name="other">Collider which is used to detect if it was a score block</param>
    private void OnTriggerExit(Collider other) {
        if (other.gameObject.CompareTag("Score")) {
            Destroy(other.gameObject);
            lvlManager.IncrementScore();
        }
    }
}
