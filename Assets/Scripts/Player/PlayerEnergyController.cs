using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerEnergyController : MonoBehaviour
{
    [SerializeField] private PlayerScriptableObject _playerScriptableObject;
    
    private float _energyRestoreTime;
    private float _maxEnergy;
    private float _currentEnergy;

    public float CurrentEnergy { 
        get 
        { 
            return _currentEnergy;
        }
        set 
        { 
            _currentEnergy = value;
            UIManager.Instance.UpdateEnergyBar(_currentEnergy);
        } 
    }
    void Start()
    {
        _energyRestoreTime = _playerScriptableObject.EnergyRestoreTime;
        _maxEnergy = _playerScriptableObject.Energy;
        _currentEnergy = _maxEnergy;
        UIManager.Instance.SetMaxEnergyBar(_maxEnergy);
        UIManager.Instance.UpdateEnergyBar(_currentEnergy);
    }

    public void IncreaseMaxEnergy(float value)
    {
        _maxEnergy += value;
        UIManager.Instance.SetMaxEnergyBar(_maxEnergy);
        StartCoroutine("StartEnergyRecovery");
    }

    public void DecreaseEnergyRecoveryTime(float value)
    {
        if (_energyRestoreTime > _playerScriptableObject.MaxEnergyRestoreTime)
        {
            _energyRestoreTime -= value;
        }
    }

    public void StartEnergyRecovery()
    {
        StopCoroutine("EnergyRecovery");
        StartCoroutine("EnergyRecovery");
    }

    private IEnumerator EnergyRecovery()
    {
        yield return new WaitForSeconds(3f);
        while (_currentEnergy < _maxEnergy)
        {
            _currentEnergy += 3f;
            UIManager.Instance.UpdateEnergyBar(_currentEnergy);
            yield return new WaitForSeconds(_energyRestoreTime);
        }
    }
}
