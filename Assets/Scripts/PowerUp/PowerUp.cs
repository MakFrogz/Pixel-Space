using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUp : MonoBehaviour
{
    [SerializeField] protected PowerUpScriptableObject _boostScriptableObject;
    [SerializeField] protected string _boostName;

    private void FixedUpdate()
    {
        transform.Translate(Vector3.down * _boostScriptableObject.Speed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            AudioManager.Instance.PlaySFX(_boostScriptableObject.AudioClip);
            ActiveBoost(other);
            GameObject popupTextObject = Instantiate(_boostScriptableObject.PopupTextPrefab, transform.position, Quaternion.identity);
            popupTextObject.transform.GetChild(0).GetComponent<TextMesh>().text = _boostName;
            Destroy(gameObject);
        }
    }

    protected abstract void ActiveBoost(Collider2D other);
    

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
