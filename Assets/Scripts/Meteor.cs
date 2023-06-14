using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : Enemy
{
    [SerializeField] private float minSpeed;
    [SerializeField] private float maxSpeed;
    private float speed;
    [SerializeField] private float rotateSpeed;

    [SerializeField] private GameObject explosion;

    [SerializeField] private ScriptableObjExample powerUpSpawner;
                     
    // Start is called before the first frame update
    void Start()
    {
        speed= Random.Range(minSpeed,maxSpeed);
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Rotate(0,0,rotateSpeed);
        rb.velocity = Vector3.down * speed;
    }

    public override void DeathSequence()
    {
        base.DeathSequence();
        if(powerUpSpawner!= null)
        {
            powerUpSpawner.SpawnPowerUp(transform.position);
        }
        Destroy(gameObject);
        Instantiate(explosion, transform.position, transform.rotation);
    }
    public override void HurtSequence()
    {
        base.HurtSequence();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerStats player = other.GetComponent<PlayerStats>();
            player.PlayerTakeDamage(damage);
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
