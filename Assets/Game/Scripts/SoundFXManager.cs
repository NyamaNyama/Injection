using System;
using UnityEngine;

public class SoundFXManager : MonoBehaviour
{
    public static SoundFXManager instance;

    [SerializeField] private AudioSource soundFXObject;
    [SerializeField] private AudioSource musicSource;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlaySoundFXClip(AudioClip clip, Transform spawnTransform, float volume)
    {
        AudioSource audioSource = Instantiate(soundFXObject, spawnTransform.position, 
            Quaternion.identity);
        audioSource.clip = clip;
        audioSource.volume = volume;
        audioSource.Play();

        float clipLength = audioSource.clip.length;
        Destroy(audioSource.gameObject);
    }
    
    public void PlayMusic(AudioClip clip, float volume = 1f, bool loop = true)
    {
        if (musicSource.isPlaying) 
        {
            musicSource.Stop(); 
        }

        musicSource.clip = clip;
        musicSource.volume = volume;
        musicSource.loop = loop; 
        musicSource.Play();
    }
}
