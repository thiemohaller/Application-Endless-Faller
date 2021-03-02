using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    public float PlayerSpeed { get; set; }

    public Movement(float playerSpeed) {
        PlayerSpeed = playerSpeed;
    }

    /// <summary>
    ///     Extracted Method for humble object pattern to make testing possible
    /// </summary>
    /// <param name="xMovement">User input</param>
    /// <param name="deltaTime"></param>
    /// <returns>A Vector3 with the calculated position</returns>
    public Vector3 Calculate(float xMovement, float deltaTime) {
        var xPos = xMovement * deltaTime * PlayerSpeed;
        return Vector3.right * xPos;
    }

}
