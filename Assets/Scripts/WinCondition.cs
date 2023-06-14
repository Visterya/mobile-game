using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCondition : MonoBehaviour
{
    private float timer;
    [SerializeField] private float possibleWinTime;

    [SerializeField] private GameObject[] spawner;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (EndGameManager.instance.gameOver == true)
            return;
        timer += Time.deltaTime;

        if (timer >= possibleWinTime)
        {
            for (int i = 0; i < spawner.Length; i++)
            {
                spawner[i].SetActive(false);
            }
            EndGameManager.instance.StartResolveSequeance();
            gameObject.SetActive(false);
        }
    }
}
