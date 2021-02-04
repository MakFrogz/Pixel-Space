using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private AudioClip _explosionSound;

    private Animator _animator;
    void Start()
    {
        StartCoroutine(CameraShake.Instance.Shake(0.15f, 0.2f));
        _animator = GetComponent<Animator>();
        if(_animator == null)
        {
            Debug.LogError("Explosion animator is NULL!");
            return;
        }
        float clipTime = _animator.runtimeAnimatorController.animationClips[0].length;
        AudioManager.Instance.PlaySFX(_explosionSound);
        Destroy(gameObject, clipTime);
    }

}
