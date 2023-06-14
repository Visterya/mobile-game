using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PowerUpHeal : MonoBehaviour
{

    [SerializeField] private int healAmount;






    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerStats player = other.GetComponent<PlayerStats>();
            player.AddHealth(healAmount);
            Destroy(gameObject);
        }
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
