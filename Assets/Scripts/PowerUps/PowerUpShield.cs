using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpShield : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerShieldActivator shieldActivator = other.GetComponent<PlayerShieldActivator>();
            shieldActivator.ActivateShield();
            Destroy(gameObject);
        }
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

}
