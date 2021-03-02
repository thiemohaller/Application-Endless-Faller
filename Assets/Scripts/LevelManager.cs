using Assets.Scripts;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary> Manages the state of the level </summary>
public class LevelManager : MonoBehaviour
{
    public int Score { get; private set; }
    public int scoreModifier = 1;
    public Text scoreText;
    public Text highScoreText;
    public Text gameOverNewHighScore;
    public Text newHighScoreBanner;
    public Text gameOverScore;
    public GameObject endScreen;

    private int newHighScore = 0;
    private int previousHighScore = 0;
    private bool firstTimeNewHighScore = true;
    
    void Start() {
        previousHighScore = PlayerPrefs.GetInt(ProjectConstants.PLAYERPREF_HIGHSCORE, 0);
        highScoreText.text = previousHighScore.ToString();
        gameOverNewHighScore.enabled = false;
        newHighScoreBanner.enabled = false;
        endScreen.SetActive(false);
    }

    void Update() {
        scoreText.text = $"Score: {Score}";
        gameOverScore.text = $"Your score: {Score}";
        highScoreText.text = $"Prev. HS: {previousHighScore}";
    }

    public void IncrementScore() {
        Score += scoreModifier;

        if (Score > previousHighScore) {
            newHighScore = Score;
            PlayerPrefs.SetInt(ProjectConstants.PLAYERPREF_HIGHSCORE, newHighScore);
            gameOverNewHighScore.enabled = true;
            if (firstTimeNewHighScore) {
                newHighScoreBanner.enabled = true;
                firstTimeNewHighScore = false;
            }
        }
    }

    public void GameOver() {
        endScreen.SetActive(true);
    }

    public void Restart() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        endScreen.SetActive(false);
    }

    public void MainMenu() {
        SceneManager.LoadScene(ProjectConstants.SCENE_MAIN_MENU);
    }
}
