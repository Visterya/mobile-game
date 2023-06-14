using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelController : MonoBehaviour
{
    [SerializeField] private CanvasGroup cGroup;
    [SerializeField] private GameObject winScreen;
    [SerializeField] private GameObject loseScreen;

    // Start is called before the first frame update
    void Start()
    {
        EndGameManager.instance.RegisterPanelController(this);
    }


    public void ActivateWin()
    {
        cGroup.alpha = 1;
        winScreen.SetActive(true);
    }
    public void ActivateLose()
    {
        cGroup.alpha = 1;
        loseScreen.SetActive(true);
    }
}
