using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField] private BoostScriptableObject _boostScriptableObject;
    [SerializeField] private int _powerUpCount;
    [SerializeField] private float _speed;
    [SerializeField] private AudioClip _audioClip;
    
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
            int boostIndex = Random.Range(0, _powerUpCount);
            if(player != null)
            {
                switch (boostIndex) {
                    case 0:
                        player.SpeedBoostActive();
                        break;
                    case 1:
                        player.GetComponent<PlayerHealthController>().ShieldActive();
                        break;
                    case 2:
                        player.GetComponent<PlayerHealthController>().HealActive(_boostScriptableObject.Heal);
                        break;
                    case 3:
                        player.GetComponent<PlayerHealthController>().AddMaxHealth(_boostScriptableObject.HealthUp);
                        break;
                    case 4:
                        player.GetComponent<PlayerEnergyController>().EnergyRestoreTime(_boostScriptableObject.EnergyRestoreTimeUp);
                        break;
                    case 5:
                        player.GetComponent<PlayerEnergyController>().SetMaxEnergy(_boostScriptableObject.EnergyUp);
                        break;
                    case 6:
                        player.GetComponent<PlayerShootController>().AddProjectile();
                        break;
                    case 7:
                        player.GetComponent<PlayerShootController>().AddFireRate(_boostScriptableObject.FireRateUp);
                        break;
                    default:
                        Debug.LogWarning("Unknown boost!");
                        break;
                }

                Destroy(gameObject);
            }
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
