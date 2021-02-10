using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField] private BoostScriptableObject _boostScriptableObject;
    [SerializeField] private int _powerUpCount;
    [SerializeField] private float _speed;
    [SerializeField] private AudioClip _audioClip;
    [SerializeField] private GameObject _popupTextPrefab;

    private void FixedUpdate()
    {
        transform.Translate(Vector3.down * _speed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();
            AudioManager.Instance.PlaySFX(_audioClip);
            string popupText = null;
            int boostIndex = Random.Range(0, _powerUpCount);
            if(player != null)
            {
                switch (boostIndex) {
                    case 0:
                        player.SpeedBoostActive(_boostScriptableObject.SpeedUp);
                        popupText = _boostScriptableObject.SpeedUpText;
                        break;
                    case 1:
                        player.GetComponent<PlayerHealthController>().ShieldActive();
                        popupText = _boostScriptableObject.ShieldText;
                        break;
                    case 2:
                        player.GetComponent<PlayerHealthController>().HealActive(_boostScriptableObject.Heal);
                        popupText = _boostScriptableObject.HealText;
                        break;
                    case 3:
                        player.GetComponent<PlayerHealthController>().AddMaxHealth(_boostScriptableObject.HealthUp);
                        popupText = _boostScriptableObject.HealthUpText;
                        break;
                    case 4:
                        player.GetComponent<PlayerEnergyController>().EnergyRestoreTime(_boostScriptableObject.EnergyRestoreTimeUp);
                        popupText = _boostScriptableObject.EnergyRestoreTimeUpText;
                        break;
                    case 5:
                        player.GetComponent<PlayerEnergyController>().SetMaxEnergy(_boostScriptableObject.EnergyUp);
                        popupText = _boostScriptableObject.EnergyUpText;
                        break;
                    case 6:
                        player.GetComponent<PlayerShootController>().AddProjectile();
                        popupText = _boostScriptableObject.ProjectileUpText;
                        break;
                    case 7:
                        player.GetComponent<PlayerShootController>().AddFireRate(_boostScriptableObject.FireRateUp);
                        popupText = _boostScriptableObject.FireRateUpText;
                        break;
                    default:
                        Debug.LogWarning("Unknown boost!");
                        break;
                }
                GameObject popupTextObject = Instantiate(_popupTextPrefab, transform.position, Quaternion.identity);
                popupTextObject.transform.GetChild(0).GetComponent<TextMesh>().text = popupText;
                Destroy(gameObject);
            }
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
