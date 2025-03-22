using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Play()
    {
        SceneController.instance.LoadScene();
    }

    public void Quit()
    {
        Application.Quit();
    }
}
