using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class FadeCanvas : MonoBehaviour
{
    public static FadeCanvas instance;

    [SerializeField] private GameObject loadingScreen;
    [SerializeField] private Image loadingBar;

    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private float changeValue;
    [SerializeField] private float waitTime;
    [SerializeField] private bool fadeStarted = false;

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

    void Start()
    {
        StartCoroutine(FadeIn());
        
    }

    public void FaderLoadString(string levelName)
    {
        StartCoroutine(FadeOutString(levelName));
    }
    public void FaderLoadInt(int levelInd)
    {
        StartCoroutine(FadeOutInt(levelInd));
    }

    IEnumerator FadeIn()
    {
        loadingScreen.SetActive(false);
        fadeStarted = false;
        while(canvasGroup.alpha > 0)
        {
            if (fadeStarted)
                yield break;
            canvasGroup.alpha -= changeValue;
            yield return new WaitForSeconds(waitTime);
        }
    }
    IEnumerator FadeOutString(string levelName)

    {
        if (canvasGroup.alpha != 0)
            yield break;

        if (fadeStarted)
            yield break;
        fadeStarted = true;
        while (canvasGroup.alpha < 1)
        {
            canvasGroup.alpha += changeValue;
            yield return new WaitForSeconds(waitTime);
        }
        AsyncOperation ao = SceneManager.LoadSceneAsync(levelName);
        ao.allowSceneActivation = false;
        loadingScreen.SetActive(true);
        loadingBar.fillAmount = 0;
        while(ao.isDone == false)
        {
            loadingBar.fillAmount = ao.progress / 0.9f;
            if(ao.progress == 0.9f)
            {
                ao.allowSceneActivation = true;
            }
            yield return null;
        }

       
        StartCoroutine(FadeIn());
    }


    IEnumerator FadeOutInt(int levelInd)

    {
        if (fadeStarted)
            yield break;
        fadeStarted = true;
        while (canvasGroup.alpha < 1)
        {
            canvasGroup.alpha += changeValue;
            yield return new WaitForSeconds(waitTime);
        }
        AsyncOperation ao = SceneManager.LoadSceneAsync(levelInd);
        ao.allowSceneActivation = false;
        loadingScreen.SetActive(true);
        loadingBar.fillAmount = 0;
        while (ao.isDone == false)
        {
            loadingBar.fillAmount = ao.progress / 0.9f;
            if (ao.progress == 0.9f)
            {
                ao.allowSceneActivation = true;
            }
            yield return null;
        }


        StartCoroutine(FadeIn());
    }



}
