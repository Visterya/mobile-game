using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private GameObject bullet;


    [Header("Basic Attack")]
    [SerializeField] private float shootingInterval;
    [SerializeField] private Transform shootingPoint;
    private float shootingReset;
    [Header("Upgrade Points")]
    [SerializeField] private Transform leftCannon;
    [SerializeField] private Transform rightCannon;
    [Header("Rotated Points")]
    [SerializeField] private Transform RotatedLeftCannon;
    [SerializeField] private Transform RotatedRightCannon;

    private int upgradeLevel;

    // Start is called before the first frame update
    void Start()
    {
        shootingReset = shootingInterval;
    }

    // Update is called once per frame
    void Update()
    {
        shootingInterval -= Time.deltaTime;
        if(shootingInterval <= 0 )
        {
            Shoot();
            shootingInterval = shootingReset;
        }
    }

    public void IncreaseUpgrade(int increaseAmount)
    {
        upgradeLevel+= increaseAmount;
        if(upgradeLevel > 2 ) 
        {
            upgradeLevel = 2;
        }

    }
    public void DecreaseUpgrade()
    {
        upgradeLevel -= 1;
        if(upgradeLevel < 0 )
        {
            upgradeLevel = 0;
        }
    }
    private void Shoot()
    {
        switch (upgradeLevel)
        {
            case 0:
                   Instantiate(bullet, shootingPoint.position, Quaternion.identity);
                break;

            case 1:
                Instantiate(bullet, shootingPoint.position, Quaternion.identity);
                Instantiate(bullet, leftCannon.position, Quaternion.identity);
                Instantiate(bullet, rightCannon.position, Quaternion.identity);
                break;

            case 2:
                Instantiate(bullet, shootingPoint.position, Quaternion.identity);
                Instantiate(bullet, leftCannon.position, Quaternion.identity);
                Instantiate(bullet, rightCannon.position, Quaternion.identity);
                Instantiate(bullet, RotatedLeftCannon.position, RotatedLeftCannon.rotation);
                Instantiate(bullet, RotatedRightCannon.position, RotatedRightCannon.rotation);
                break;
            default:
                break;

        }
    }
}
