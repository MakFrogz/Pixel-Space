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

    public static UIManager Instance { get; set; }
    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        _scoreText.text = "Score: 0";
        _gameOverText.gameObject.SetActive(false);
        _restartText.gameObject.SetActive(false);
    }

    public void UpdateScore(int playerScore)
    {
        _scoreText.text = "Score: " + playerScore.ToString();
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


    public void GameOverSequence()
    {
        _gameOverText.gameObject.SetActive(true);
        _restartText.gameObject.SetActive(true);
        StartCoroutine(GameOverFlickerRoutine());
    }

    private IEnumerator GameOverFlickerRoutine()
    {
        while (true)
        {
            _gameOverText.text = "GAME OVER";
            yield return new WaitForSeconds(0.5f);
            _gameOverText.text = "";
            yield return new WaitForSeconds(0.5f);
        }
    }

    public void ShowGameOverText(bool value)
    {
        _gameOverText.gameObject.SetActive(value);
        _restartText.gameObject.SetActive(value);
    }

}
