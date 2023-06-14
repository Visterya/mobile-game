using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedEnemy : Enemy
{
    [SerializeField] private float speed;
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform leftCannon;
    [SerializeField] private Transform rightCannon;
    [SerializeField] private float timeInterval;
    private float shootTimer = 0f;

    // Start is called before the first frame update
    void Start()
    {
    
    }
    void Update()
    {
        shootTimer += Time.deltaTime;
        if(shootTimer >= timeInterval)
        {
            Instantiate(bullet, leftCannon.position, Quaternion.identity);
            Instantiate(bullet, rightCannon.position, Quaternion.identity);
            shootTimer = 0;
        }
        
    }
    void FixedUpdate()
    {
        rb.velocity = Vector2.down * speed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerStats>().PlayerTakeDamage(damage);
            Instantiate(explosionPrefab, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

    public override void HurtSequence()
    {
        base.HurtSequence();
    }
    public override void DeathSequence()
    {
        base.DeathSequence();
        Instantiate(explosionPrefab, transform.position, transform.rotation);
        Destroy(gameObject);
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
