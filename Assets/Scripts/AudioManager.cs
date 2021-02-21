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
        _background.volume = PlayerPrefs.GetFloat("music", 1f);
        _audioSource.volume = PlayerPrefs.GetFloat("sfx", 1f);
        Debug.Log("Music volume: " + _background.volume);
        Debug.Log("SFX volume: " + _audioSource.volume);
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

    public void ChangeMusicVolume(float volume)
    {
        _background.volume = volume;
        PlayerPrefs.SetFloat("music", volume);
    }

    public void ChangeSFXVolume(float volume)
    {
        _audioSource.volume = volume;
        PlayerPrefs.SetFloat("sfx", volume);
    }
}
