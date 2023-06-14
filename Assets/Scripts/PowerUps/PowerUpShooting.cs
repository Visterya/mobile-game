using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpShooting : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerShooting player= other.GetComponent<PlayerShooting>();
            player.IncreaseUpgrade(1);
            Destroy(gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
