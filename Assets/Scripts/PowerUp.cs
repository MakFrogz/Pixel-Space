using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField] private int _powerUpCount;
    [SerializeField] private float _speed;
    [SerializeField] private AudioClip _audioClip;
    
    void Start()
    {
        /*float spriteSizeX = GetComponent<SpriteRenderer>().bounds.size.x;
        float spriteSizeY = GetComponent<SpriteRenderer>().bounds.size.y;
        float x = Background.Instance.GetBackgroundWidth() - (spriteSizeX / 2);
        float y = Background.Instance.GetBackgroundHeigth() - (spriteSizeY / 2);
        transform.position = new Vector3(Random.Range(-x, x) , y + 2f, 0f);*/
    }


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
                        player.GetComponent<PlayerHealthController>().HealActive(25f);
                        break;
                    case 3:
                        player.GetComponent<PlayerHealthController>().AddMaxHealth();
                        break;
                    case 4:
                        player.GetComponent<PlayerEnergyController>().EnergyRestoreTime();
                        break;
                    case 5:
                        player.GetComponent<PlayerEnergyController>().SetMaxEnergy();
                        break;
                    case 6:
                        player.GetComponent<PlayerShootController>().AddProjectile();
                        break;
                    case 7:
                        player.GetComponent<PlayerShootController>().AddFireRate();
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
