using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBarsUI : MonoBehaviour
{
    [SerializeField] private Slider _healthBar;
    [SerializeField] private Slider _energyBar;
    [SerializeField] private GameObject _barsHolder;

    void Start()
    {
        //_healthBar.gameObject.SetActive(false);
        //_energyBar.gameObject.SetActive(false);
        _barsHolder.SetActive(false);
    }

    public void SetMaxHealthBar(float maxHealth)
    {
        _healthBar.maxValue = maxHealth;
    }

    public void SetMaxEnergyBar(float maxEnergy)
    {
        _energyBar.maxValue = maxEnergy;
    }

    public void UpdateHealthBar(float health)
    {
        //_healthBar.gameObject.SetActive(true);
        _healthBar.value = health;
        StopCoroutine("ShowPlayerBars");
        StartCoroutine("ShowPlayerBars");
        /*StopCoroutine("TurnOffHealthBar");
        StartCoroutine("TurnOffHealthBar");*/
    }

    public void UpdateEnergyBar(float energy)
    {
        //_energyBar.gameObject.SetActive(true);
        _energyBar.value = energy;
        StopCoroutine("ShowPlayerBars");
        StartCoroutine("ShowPlayerBars");
        /* StopCoroutine("TurnOffEnergyBar");
         StartCoroutine("TurnOffEnergyBar");*/
    }

    /*public void ShowEnergyBar()
    {
        StopCoroutine("TurnOffEnergyBar");
        StartCoroutine("TurnOffEnergyBar");
    }

    private IEnumerator TurnOffHealthBar()
    {
        yield return new WaitForSeconds(3f);
        _healthBar.gameObject.SetActive(false);
    }

    private IEnumerator TurnOffEnergyBar()
    {
        Debug.Log("TurnOffEnergyBar start");
        yield return new WaitForSeconds(3f);
        _energyBar.gameObject.SetActive(false);
        Debug.Log("TurnOffEnergyBar stop");
    }*/

    public IEnumerator ShowPlayerBars()
    {
        _barsHolder.SetActive(true);
        yield return new WaitForSeconds(3f);
        _barsHolder.SetActive(false);
    }
}
