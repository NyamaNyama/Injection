using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private AudioClip menuMusic;

    private void Start()
    {
        SoundFXManager.instance.PlayMusic(menuMusic);
    }

    public void Play()
    {
        SceneController.instance.LoadScene();
    }

    public void Quit()
    {
        Application.Quit();
    }
}