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

    private UIManager _uiManager;

    public GameManagerInput _inputActions;

    public bool IsGameOver { get; private set; }


    private void Awake()
    {
        Instance = this;
        _inputActions = new GameManagerInput();
    }
    private void Start()
    {
        _uiManager = GameObject.Find("UI Manager").GetComponent<UIManager>();
        _inputActions.Gamemanager.Restart.performed += ctx => OnRestart();
        _inputActions.Gamemanager.Pause.performed += ctx => OnPause();
    }

    public void OnPause()
    {
        Debug.Log("Game Pause");
        _pausePanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void OnRestart()
    {
        Debug.Log("Restart level!");
        if (IsGameOver)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void GameOver()
    {
        _uiManager.GameOverSequence();
        IsGameOver = true;
    }

    public void AddScore(int score)
    {
        Score += score;
        _uiManager.UpdateScore(Score);
        SpawnManager.Instance.UpdateSpawnEnemiesRate(Score);
    }
    
    public void Resume()
    {
        _pausePanel.SetActive(false);
        Time.timeScale = 1f;
    }
    public void LoadMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void OnBossDeath()
    {
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
