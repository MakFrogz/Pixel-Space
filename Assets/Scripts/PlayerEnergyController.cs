using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerEnergyController : MonoBehaviour
{
    [SerializeField] private PlayerScriptableObject _playerScriptableObject;
    [SerializeField] private float _energyRestoreTime;

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
        _maxEnergy = _playerScriptableObject.PlayerEnergy;
        _currentEnergy = _maxEnergy;
        UIManager.Instance.SetMaxEnergyBar(_maxEnergy);
        UIManager.Instance.UpdateEnergyBar(_currentEnergy);
    }

    public void SetMaxEnergy()
    {
        _maxEnergy += 10f;
        UIManager.Instance.SetMaxEnergyBar(_maxEnergy);
    }

    public void EnergyRestoreTime()
    {
        if (_energyRestoreTime > 0.5f)
        {
            _energyRestoreTime -= 0.1f;
        }
    }

    public void StartEnergyRestore()
    {
        StopCoroutine("EnergyRestore");
        StartCoroutine("EnergyRestore");
    }

    private IEnumerator EnergyRestore()
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
