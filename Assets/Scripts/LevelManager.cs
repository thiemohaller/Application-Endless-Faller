using System;
using UnityEngine;
using UnityEngine.UI;

/// <summary> Manages the state of the level </summary>
public class LevelManager : MonoBehaviour
{
    public int Score { get; private set; }
    public int scoreModifier = 1;
    public Text scoreText;
    
    void Start() {
        
    }

    void Update() {
        scoreText.text = $"Score: {Score}";
    }

    public void IncrementScore() {
        Score += scoreModifier;
    }

    public void Reset() {
        Score = 0;
        // reset logic
    }
}
