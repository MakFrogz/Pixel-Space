using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Text _gameTitle;
    [SerializeField] private GameObject _mainMenuPanel;
    [SerializeField] private GameObject _creditsPanel;
    [SerializeField] private GameObject _settingsPanel;
    [SerializeField] private Slider _musicSlider;
    [SerializeField] private Slider _sfxSlider;

    private GameObject _currentPanel;

    private MainMenuInputs _inputActions;
    private void Awake()
    {
        _currentPanel = _mainMenuPanel;
        _musicSlider.value = PlayerPrefs.GetFloat("music", 1f);
        _sfxSlider.value = PlayerPrefs.GetFloat("sfx", 1f);
        _musicSlider.onValueChanged.AddListener(delegate { AudioManager.Instance.SetMusicVolume(_musicSlider.value); });
        _sfxSlider.onValueChanged.AddListener(delegate { AudioManager.Instance.SetSFXVolume(_sfxSlider.value); });
        _inputActions = new MainMenuInputs();
        _inputActions.UI.Cancel.performed += ctx => ShowMainMenu();
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ShowCredits()
    {
        _gameTitle.gameObject.SetActive(false);
        ShowCurrentPanel(_creditsPanel);
    }

    public void ShowMainMenu()
    {
        _gameTitle.gameObject.SetActive(true);
        ShowCurrentPanel(_mainMenuPanel);
        EventSystem.current.SetSelectedGameObject(_currentPanel.transform.GetChild(0).gameObject);
    }

    public void ShowSettings()
    {
        ShowCurrentPanel(_settingsPanel);
        EventSystem.current.SetSelectedGameObject(_currentPanel.transform.GetChild(0).gameObject);
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

    private void OnEnable()
    {
        _inputActions.UI.Enable();
    }

    private void OnDisable()
    {
        _inputActions.UI.Disable();
    }
}
