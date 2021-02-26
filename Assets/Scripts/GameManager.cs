using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; set; }

    public int Score { get; set; }
    public int DestroyedEnemiesCount { get; set; }
    public float MultiplierHealth { get; private set; }
    public bool IsGameOver { get; private set; }
    public bool IsPause { get; set; }

    private GameManagerInputs _inputActions;

    private void Awake()
    {
        Instance = this;
        MultiplierHealth = 1;
        _inputActions = new GameManagerInputs();
        _inputActions.GameManager.Pause.performed += ctx => OnPause();
        _inputActions.GameManager.Restart.performed += ctx => OnRestart();
    }

    public void OnPause()
    {
        UIManager.Instance.ShowPauseMenu(true);
        UIManager.Instance.ShowPlayerUIPanel(false);
        if (IsGameOver)
        {
            UIManager.Instance.GameOverSequence(false);
        }
        Time.timeScale = 0f;
        IsPause = true;
    }

    public void OnRestart()
    {
        if (IsGameOver)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void GameOver()
    {
        int highScore = PlayerPrefs.GetInt("highscore", 0);
        if(highScore < Score)
        {
            PlayerPrefs.SetInt("highscore", Score);
        }
        UIManager.Instance.GameOverSequence(true);
        AudioManager.Instance.GameOverMusic();
        IsGameOver = true;
    }

    public void AddScore(int score)
    {
        Score += score;
        UIManager.Instance.UpdateScore(Score);
        SpawnManager.Instance.UpdateSpawnEnemiesRate(Score);
    }
    
    public void Resume()
    {
        UIManager.Instance.ShowPauseMenu(false, null);
        UIManager.Instance.ShowPlayerUIPanel(true);
        if (IsGameOver)
        {
            UIManager.Instance.GameOverSequence(true);
        }
        Time.timeScale = 1f;
        IsPause = false;
    }
    public void LoadMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void OnBossDeath()
    {
        MultiplierHealth += 0.25f;
        StartCoroutine(SpawnManager.Instance.ContinueSpawn());
    }

    private void OnEnable()
    {
        _inputActions.GameManager.Enable();
    }

    private void OnDisable()
    {
        _inputActions.GameManager.Disable();
    }

}
