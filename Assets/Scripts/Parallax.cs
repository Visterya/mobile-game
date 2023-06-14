using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField] private float parallaxSpeed;
    private float spriteHeight;
    private Vector3 startPos;
    // Start is called before the first frame update
    void Start()
    {
        spriteHeight = GetComponent<SpriteRenderer>().bounds.size.y;
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * parallaxSpeed * Time.deltaTime);
        if(transform.position.y < startPos.y - spriteHeight)
        {
            transform.position = startPos;
        }
    }
}
