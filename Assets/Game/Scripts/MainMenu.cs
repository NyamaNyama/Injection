using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private AudioClip MenuMusic;

    private void Awake()
    {
        SoundFXManager.instance.PlayMusic(MenuMusic);
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
