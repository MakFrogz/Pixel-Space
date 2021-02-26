using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Text _scoreText;
    [SerializeField] private Text _gameOverText;
    [SerializeField] private Text _restartText;
    [SerializeField] private Slider _healthBar;
    [SerializeField] private Slider _energyBar;
    [SerializeField] private Text _highScoreResultText;
    [SerializeField] private Text _scoreResultText;

    [SerializeField] private GameObject _scorePanel;
    [SerializeField] private GameObject _playerUIPanel;
    [SerializeField] private GameObject _pausePanel;

    public static UIManager Instance { get; set; }
    private void Awake()
    {
        Instance = this;
        _scorePanel.SetActive(false);
        _playerUIPanel.SetActive(true);
        _highScoreResultText.text = PlayerPrefs.GetInt("highscore", 0).ToString();
        _scoreText.text = "Score: 0";
        _scoreResultText.text = "0";
    }

    void Start()
    {
        _gameOverText.gameObject.SetActive(false);
        _restartText.gameObject.SetActive(false);
    }

    public void UpdateScore(int playerScore)
    {
        _scoreText.text = "Score: " + playerScore.ToString();
        _scoreResultText.text = playerScore.ToString();
    }

    public void SetRestartText(string controlName)
    {
        switch (controlName)
        {
            case "Keyboard":
                _restartText.text = "Press  R  key  to  restart  level";
                break;
            case "Gamepad":
                _restartText.text = "Press  Select  key  to  restart  level";
                break;
            default:
                Debug.LogError("Unkhown  control:" + (controlName == null? "NULL" : controlName)); ;
                break;
        }
    }

    public void SetMaxHealthBar(float maxHealth)
    {
        _healthBar.maxValue = maxHealth;
    }

    public void UpdateHealthBar(float currentHealth)
    {
        _healthBar.value = currentHealth;
    }

    public void SetMaxEnergyBar(float maxEnergy)
    {
        _energyBar.maxValue = maxEnergy;
    }

    public void UpdateEnergyBar(float currentEnergy)
    {
        _energyBar.value = currentEnergy;
    }


    public void GameOverSequence(bool val)
    {
        _gameOverText.gameObject.SetActive(val);
        _restartText.gameObject.SetActive(val);
        _scorePanel.SetActive(val);
        ShowPlayerUIPanel(false);
    }

    public void ShowPlayerUIPanel(bool value)
    {
        _playerUIPanel.SetActive(value);
    }

    public void ShowPauseMenu(bool val)
    {
        _pausePanel.SetActive(val);
        EventSystem.current.SetSelectedGameObject(_pausePanel.transform.GetChild(0).gameObject);
    }

    public void ShowPauseMenu(bool val, GameObject _gameObject)
    {
        _pausePanel.SetActive(val);
        EventSystem.current.SetSelectedGameObject(_gameObject);
    }
}
