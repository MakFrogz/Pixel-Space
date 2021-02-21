using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject _mainMenuPanel;
    [SerializeField] private GameObject _creditsPanel;

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ShowCredits()
    {
        _mainMenuPanel.SetActive(false);
        _creditsPanel.SetActive(true);
    }

    public void ShowMainMenu()
    {
        _mainMenuPanel.SetActive(true);
        _creditsPanel.SetActive(false);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
