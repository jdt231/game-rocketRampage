using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    AudioSource audioSource;

    public AudioClip menuMusic;
    public AudioClip[] soundtrack;

    public bool newScene = false;

    private void Awake()
    {
        int numMusicPlayers = FindObjectsOfType<MusicPlayer>().Length;

        if (numMusicPlayers > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = PlayerPrefsController.GetMasterVolume();
    }

    public void ChangeMusic()
    {
        if (newScene != true) { return; } // If retrying the same level, don't change the music.

            audioSource.clip = soundtrack[Random.Range(0, soundtrack.Length)];
            audioSource.Play();
            newScene = false;
    }

    public void PlayMenuMusic()
    {
        if (audioSource.clip != menuMusic)
        {
            audioSource.clip = menuMusic;
            audioSource.Play();
        }
        else { return; }
    }

    public void SetVolume(float volume)
    {
        audioSource.volume = volume;
    }
}
