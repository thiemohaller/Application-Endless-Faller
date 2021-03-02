using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour {

    public Text highScoreText;

    private int HighScore { get; set; }

    void Start() {
        HighScore = PlayerPrefs.GetInt(ProjectConstants.PLAYERPREF_HIGHSCORE);
        highScoreText.text = $"High Score: {HighScore}";
    }

    private void Update() {
        highScoreText.text = $"HighScore: {HighScore}";
    }

    public void ResetHighScore() {
        HighScore = 0;
        highScoreText.text = "High Score: 0";
        PlayerPrefs.DeleteKey(ProjectConstants.PLAYERPREF_HIGHSCORE);
    }
}
