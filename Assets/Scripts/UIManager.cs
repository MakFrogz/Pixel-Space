using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
}
