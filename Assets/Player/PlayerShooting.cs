using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] float fireRate;
    public float ProjectileSpeed;
    public TargetScanner Scanner;
    [SerializeField] GameObject projectile;
    [SerializeField] Transform projectileSpawnPoint;
    public float Damage;
    float timer;
    private void Update()
    {
        timer += Time.deltaTime;
        if (Scanner.enemiesInRange.Count != 0 && timer >= fireRate)
        {
            timer = 0;
            GameObject instBullet = Instantiate(projectile, projectileSpawnPoint.position, Quaternion.identity);

            PlayerProjectile playerProjectile = instBullet.GetComponent<PlayerProjectile>();

            playerProjectile.playerShooting = this;
        }
    }
}
