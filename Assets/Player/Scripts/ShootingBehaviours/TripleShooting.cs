using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Shoot Behaviours/Triple Shooting")]
public class TripleShooting : ShootBehaviourBaseClass
{
    public float Damage;
    public float ProjectileSpeed;
    public float FireRate;
    public float ConeAngle;
    public int ProjectileCount;


    float timer;

    public override void Shoot(PlayerShooting playerShooting)
    {
        timer += Time.deltaTime;
        if (playerShooting.Scanner.enemiesInRange.Count != 0 && timer >= FireRate)
        {
            timer = 0;
            float cone = ConeAngle / ProjectileCount;
            playerShooting.transform.LookAt(playerShooting.Scanner.enemiesInRange[0].transform);
            for (int i = 0; i < ProjectileCount; i++)
            {

                GameObject instBullet = Instantiate(playerShooting.Projectile, playerShooting.ProjectileSpawnPoint.position, playerShooting.ProjectileSpawnPoint.rotation);


                instBullet.transform.rotation = Quaternion.Euler(0, instBullet.transform.rotation.eulerAngles.y + cone * i - ConeAngle / 2, 0);



                PlayerProjectile playerProjectile = instBullet.GetComponent<PlayerProjectile>();

                playerProjectile.playerShooting = playerShooting;
                playerProjectile.Damage = Damage;
                playerProjectile.ProjectileSpeed = ProjectileSpeed;
            }
        }
    }
}
