using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    private PlayerShooting playerShooting;
    [SerializeField] private Animator anim;
    [SerializeField] private float playerHealth;
    private float currentHealth;
    [SerializeField] private Image healthFill;

    [SerializeField] private GameObject explosion;
    [SerializeField] private Shield shield;

    private bool canPlayAnim = true;
    // Start is called before the first frame update
    void Start()
    {
        EndGameManager.instance.gameOver = false;
        currentHealth = playerHealth;
        healthFill.fillAmount = currentHealth / playerHealth;
        playerShooting= GetComponent<PlayerShooting>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayerTakeDamage(int damage)
    {
        if (shield.protection)
            return;
        currentHealth -= damage;
        if(canPlayAnim)
        {
            anim.SetTrigger("Damage");
            StartCoroutine(AntiSpamAnimation());
        }
        playerShooting.DecreaseUpgrade();
        healthFill.fillAmount = currentHealth / playerHealth;
        if (currentHealth <= 0)
        {
            EndGameManager.instance.gameOver= true;
            EndGameManager.instance.StartResolveSequeance();
            Destroy(gameObject);
            Instantiate(explosion, transform.position, transform.rotation);
        }
    }
    private IEnumerator AntiSpamAnimation() 
    { 
        canPlayAnim= false;
        yield return new WaitForSeconds(.4f);
        canPlayAnim= true;
    }

    public void AddHealth(int healAmount)
    {
        currentHealth += healAmount;
        if(currentHealth > playerHealth)
        {
            currentHealth = playerHealth;
        }
        healthFill.fillAmount = currentHealth / playerHealth;
    }
}
