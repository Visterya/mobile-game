using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class EndGameManager : MonoBehaviour
{
    public static EndGameManager instance;
    public bool gameOver;

    private PanelController panelController;

    private TextMeshProUGUI scoreTextComponent;
    private int score;

    [HideInInspector]
    public string lvlUnlock = "LevelUnlock";
    private void Awake()
    {
        if(instance == null)
        {
            instance= this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        
    }

    public void StartResolveSequeance()
    {
        StopCoroutine(nameof(ResolveGameSequeance));
        StartCoroutine(ResolveGameSequeance());
    }
    private IEnumerator ResolveGameSequeance()
    {
        yield return new WaitForSeconds(2);
        ResolveGame();
    }
    public void ResolveGame()
    {
        if(gameOver ==false)
        {
            WinGame();
        }
        else
        {
            LoseGame();
        }
    }

    public void WinGame()
    {
        ScoreSet();
        panelController.ActivateWin();
        int nextLevel = SceneManager.GetActiveScene().buildIndex + 1;
        if(nextLevel > PlayerPrefs.GetInt(lvlUnlock, 0))
        {
            PlayerPrefs.SetInt(lvlUnlock, nextLevel);
        }
    }
    public void LoseGame()
    {
        ScoreSet();
        panelController.ActivateLose();
    }

    public void RegisterPanelController(PanelController pC)
    {
        panelController= pC;
    }
    public void RegisterScoreText(TextMeshProUGUI scoreTextComp)
    {
        scoreTextComponent= scoreTextComp;
    }
    public void AddScore(int addScore)
    {
        score += addScore;
        scoreTextComponent.text = "Score: " + score.ToString();
    }
    public void ScoreSet()
    {
        PlayerPrefs.SetInt("Score" + SceneManager.GetActiveScene().name, score);
        int highScore = PlayerPrefs.GetInt("HighScore" + SceneManager.GetActiveScene().name, 0);
        if(score > highScore)
        {
            PlayerPrefs.SetInt("HighScore" + SceneManager.GetActiveScene().name, score);
        }
        score = 0;
    }
}
