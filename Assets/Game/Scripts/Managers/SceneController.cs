using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public static SceneController instance;
    [SerializeField] private Animator transitionAnim;
    [SerializeField] private AudioClip gameMusic;
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

    public void LoadScene()
    {
        StartCoroutine(LoadGame());
    }

    private IEnumerator LoadGame()
    {
        transitionAnim.SetTrigger("Start");
        yield return new WaitForSeconds(1f);
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Game");
        asyncLoad.allowSceneActivation = false;
        
        while (!asyncLoad.isDone)
        {
            if (asyncLoad.progress >= 0.9f)
            {
                break;
            }
            yield return null;
        }
        
        asyncLoad.allowSceneActivation = true;
        
        yield return new WaitUntil(() => asyncLoad.isDone);
        transitionAnim.SetTrigger("End");
        SoundFXManager.instance.PlayMusic(gameMusic,0.2f);
    }
    
    
}
