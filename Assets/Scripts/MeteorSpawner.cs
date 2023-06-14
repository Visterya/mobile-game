using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{
    [SerializeField] private GameObject meteor;
    [SerializeField] private float spawnTime;
    private float timer = 0f;

    private Camera mainCam;
    private float maxLeft;
    private float maxRight;
    private float yPos;


    // Start is called before the first frame update
    void Start()
    {
        mainCam = Camera.main;
        StartCoroutine(SettingBoundries());
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer> spawnTime)
        {
            GameObject obj = Instantiate(meteor, new Vector3(Random.Range(maxLeft,maxRight), yPos, -5), Quaternion.Euler(0,0,Random.Range(0,360)));
            float size = Random.Range(0.9f, 1.1f);
            obj.transform.localScale = new Vector3(size, size, 1);
            timer = 0f; 
        }
        
    }

    private IEnumerator SettingBoundries()
    {
        yield return new WaitForSeconds(0.4f);

        maxLeft = mainCam.ViewportToWorldPoint(new Vector2(.15f, 0)).x;
        maxRight = mainCam.ViewportToWorldPoint(new Vector2(.85f, 0)).x;
        yPos = mainCam.ViewportToWorldPoint(new Vector2(0, 1.1f)).y;
    }
}
