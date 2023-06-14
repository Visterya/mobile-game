using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float damage;
    [SerializeField] private Rigidbody2D rb;


    void Start()
    {
        
    }

    void FixedUpdate()
    {
        rb.velocity = transform.up* speed;
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Enemy enemy = other.GetComponent<Enemy>();
        enemy.TakeDamage(damage);
        Destroy(gameObject);
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
