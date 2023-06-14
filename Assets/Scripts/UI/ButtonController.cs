using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    public void LoadLevelString(string sceneName)
    {
        FadeCanvas.instance.FaderLoadString(sceneName);
    }
    public void RestartLevel()
    {
        FadeCanvas.instance.FaderLoadInt(SceneManager.GetActiveScene().buildIndex);
    }

}
