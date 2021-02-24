using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; set; }

    [SerializeField] private GameObject _pausePanel;
    
    public GameManagerInput _inputActions;
    private Player _player;

    public int Score { get; set; }
    public int DestroyedEnemiesCount { get; set; }
    public float MultiplierHealth { get; private set; }
    public bool IsGameOver { get; private set; }

    private void Awake()
    {
        Instance = this;
        MultiplierHealth = 1;
        _inputActions = new GameManagerInput();
    }
    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        _inputActions.Gamemanager.Restart.performed += ctx => OnRestart();
        _inputActions.Gamemanager.Pause.performed += ctx => OnPause();
    }

    public void OnPause()
    {
        _pausePanel.SetActive(true);
        EventSystem.current.SetSelectedGameObject(_pausePanel.transform.GetChild(0).gameObject);
        UIManager.Instance.ShowPlayerUIPanel(false);
        if (IsGameOver)
        {
            UIManager.Instance.GameOverSequence(false);
        }
        Time.timeScale = 0f;
        if(_player != null)
        {
            _player.DisableInput();
        }
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
        EventSystem.current.SetSelectedGameObject(null);
        UIManager.Instance.ShowPlayerUIPanel(true);
        if (IsGameOver)
        {
            UIManager.Instance.GameOverSequence(true);
        }
        Time.timeScale = 1f;
        if(_player != null)
        {
            _player.EnableInput();
        }
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
