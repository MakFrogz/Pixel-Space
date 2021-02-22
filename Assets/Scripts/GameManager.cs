using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; set; }

    [SerializeField] private GameObject _pausePanel;
    public int Score { get; set; }
    public int DestroyedEnemiesCount { get; set; }
    public float MultiplierHealth { get; private set; }

    public GameManagerInput _inputActions;

    public bool IsGameOver { get; private set; }


    private void Awake()
    {
        Instance = this;
        MultiplierHealth = 1;
        _inputActions = new GameManagerInput();
    }
    private void Start()
    {
        _inputActions.Gamemanager.Restart.performed += ctx => OnRestart();
        _inputActions.Gamemanager.Pause.performed += ctx => OnPause();
    }

    public void OnPause()
    {
        _pausePanel.SetActive(true);
        UIManager.Instance.ShowPlayerUIPanel(false);
        if (IsGameOver)
        {
            UIManager.Instance.GameOverSequence(false);
        }
        Time.timeScale = 0f;
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
        _pausePanel.SetActive(false);
        UIManager.Instance.ShowPlayerUIPanel(true);
        if (IsGameOver)
        {
            UIManager.Instance.GameOverSequence(true);
        }
        Time.timeScale = 1f;
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
        _inputActions.Gamemanager.Enable();
    }

    private void OnDisable()
    {
        _inputActions.Gamemanager.Disable();
    }
}
