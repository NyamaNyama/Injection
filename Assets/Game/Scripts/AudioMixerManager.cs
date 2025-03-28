using UnityEngine;
using UnityEngine.Audio;
public class AudioMixerManager : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;


    public void SetMasterVolume(float level)
    {
        audioMixer.SetFloat("masterVolume", Mathf.Log10(level) * 20);
    }
    public void SetSoundFxVolume(float level)
    {
        audioMixer.SetFloat("soundFXVolume", Mathf.Log10(level) * 20);
    }
    public void SetMusicVolume(float level)
    {
        audioMixer.SetFloat("musicVolume", Mathf.Log10(level) * 20);
    }
}
