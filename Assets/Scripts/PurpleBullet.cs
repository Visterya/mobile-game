using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurpleBullet : MonoBehaviour
{
    [SerializeField] private int damage;
    [SerializeField] private float speed;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb= GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = Vector2.down * speed;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerStats>().PlayerTakeDamage(damage);
            Destroy(gameObject);
        }
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
