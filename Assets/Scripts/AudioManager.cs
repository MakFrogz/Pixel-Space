using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioClip _gameOverMusic;

    private AudioSource _audioSource;
    private AudioSource _background;
    public static AudioManager Instance { get; set; }
    private void Awake()
    {
        Instance = this;
        _audioSource = GetComponent<AudioSource>();
        _background = GameObject.Find("Background_music").GetComponent<AudioSource>();
    }

    public void PlaySFX(AudioClip audioClip)
    {
        _audioSource.PlayOneShot(audioClip);
    }

    public void GameOverMusic()
    {
        _background.Stop();
        _background.clip = _gameOverMusic;
        _background.Play();
    }
}
