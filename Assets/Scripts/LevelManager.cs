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
    public Spawner platformSpawner;
    public int secondsBetweenDifficultyIncrease = 5;

    private int newHighScore = 0;
    private int previousHighScore = 0;
    private bool firstTimeNewHighScore = true;
    private float timePassed;
    
    void Start() {
        previousHighScore = PlayerPrefs.GetInt(ProjectConstants.PLAYERPREF_HIGHSCORE, 0);
        highScoreText.text = previousHighScore.ToString();
        gameOverNewHighScore.enabled = false;
        newHighScoreBanner.gameObject.SetActive(false);
        endScreen.SetActive(false);
        timePassed = 0f;
    }

    void Update() {
        scoreText.text = $"Score: {Score}";
        gameOverScore.text = $"Your score: {Score}";
        highScoreText.text = $"Prev. HS: {previousHighScore}";

        timePassed += Time.deltaTime;
        if (timePassed > secondsBetweenDifficultyIncrease) {
            platformSpawner.platformSpeed += 0.01f;
            platformSpawner.timeBetweenSpawns -= 0.5f;
            Debug.Log("Increasing difficulty");
            if (platformSpawner.timeBetweenSpawns <= 1f) {
                platformSpawner.timeBetweenSpawns = 1f;
                Debug.Log("Cannot go lower");
            }

            timePassed = 0f;
        }
    }

    public void IncrementScore() {
        Score += scoreModifier;

        if (Score > previousHighScore) {
            newHighScore = Score;
            PlayerPrefs.SetInt(ProjectConstants.PLAYERPREF_HIGHSCORE, newHighScore);
            gameOverNewHighScore.enabled = true;

            if (firstTimeNewHighScore) {
                newHighScoreBanner.gameObject.SetActive(true);
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
