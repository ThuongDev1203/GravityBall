using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource sfxSource;

    public AudioClip backgroundMusic;
    public AudioClip jumpSound;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayBackgroundMusic()
    {
        musicSource.loop = true; // Lặp lại nhạc nền
        musicSource.clip = backgroundMusic;
        musicSource.Play();
    }

    public void PlaySFXSound(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }

    public void StopBackgroundMusic()
    {
        musicSource.Stop();
    }
}
