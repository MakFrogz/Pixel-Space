using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    [SerializeField] private PlayerScriptableObject _playerScriptableObject;
    [SerializeField] private GameObject _shield;
    [SerializeField] private GameObject _explosionPrefab;

    private float _maxHealth;
    private float _currentHealth;
    private bool _isShieldActive;
    private bool _isInvulnerable;
    public bool IsInvulnerable { get; set; }

    void Start()
    {
        _maxHealth = _playerScriptableObject.PlayerHealth;
        _currentHealth = _maxHealth;
        _isInvulnerable = false;
        UIManager.Instance.SetMaxHealthBar(_maxHealth);
        UIManager.Instance.UpdateHealthBar(_currentHealth);
    }

    public void ApplyDamage(float damage)
    {
        if (_isShieldActive)
        {
            _isShieldActive = false;
            _shield.SetActive(false);
            return;
        }

        if (_isInvulnerable)
        {
            return;
        }
        _currentHealth -= damage;
        UIManager.Instance.UpdateHealthBar(_currentHealth);
        if (_currentHealth <= 0)
        {
            GameManager.Instance.GameOver();
            Instantiate(_explosionPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    public void HealActive(float health)
    {
        _currentHealth += health;
        if (_currentHealth > _maxHealth)
        {
            _currentHealth = _maxHealth;
        }
        UIManager.Instance.UpdateHealthBar(_currentHealth);
    }

    public void AddMaxHealth()
    {
        _maxHealth += 15;
        UIManager.Instance.SetMaxHealthBar(_maxHealth);
    }

    public void ShieldActive()
    {
        _isShieldActive = true;
        _shield.SetActive(true);
    }

}
