using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject _mainMenuPanel;
    [SerializeField] private GameObject _creditsPanel;
    [SerializeField] private GameObject _settingsPanel;
    [SerializeField] private Slider _musicSlider;
    [SerializeField] private Slider _sfxSlider;

    private GameObject _currentPanel;

    private void Awake()
    {
        _currentPanel = _mainMenuPanel;
        _musicSlider.value = PlayerPrefs.GetFloat("music", 1f);
        _sfxSlider.value = PlayerPrefs.GetFloat("sfx", 1f);
        _musicSlider.onValueChanged.AddListener(delegate { AudioManager.Instance.SetMusicVolume(_musicSlider.value); });
        _sfxSlider.onValueChanged.AddListener(delegate { AudioManager.Instance.SetSFXVolume(_sfxSlider.value); });
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ShowCredits()
    {
        ShowCurrentPanel(_creditsPanel);
    }

    public void ShowMainMenu()
    {
        ShowCurrentPanel(_mainMenuPanel);
    }

    public void ShowSettings()
    {
        ShowCurrentPanel(_settingsPanel);
    }

    private void ShowCurrentPanel(GameObject panel)
    {
        _currentPanel.SetActive(false);
        _currentPanel = panel;
        _currentPanel.SetActive(true);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
