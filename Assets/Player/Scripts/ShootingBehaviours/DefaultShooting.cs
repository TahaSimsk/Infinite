using UnityEngine;

[CreateAssetMenu(menuName = "Shoot Behaviours/Default Shooting")]
public class DefaultShooting : ShootBehaviourBaseClass
{

    float timer;


    public override void Shoot(PlayerShooting playerShooting)
    {
        
        timer += Time.deltaTime;
        if (playerShooting.Scanner.enemiesInRange.Count != 0 && timer >= playerShooting.FireRate)
        {
            playerShooting.transform.LookAt(playerShooting.Scanner.enemiesInRange[0].transform);
            timer = 0;
            GameObject instBullet = Object.Instantiate(playerShooting.Projectile, playerShooting.ProjectileSpawnPoint.position, playerShooting.ProjectileSpawnPoint.rotation);

            PlayerProjectile playerProjectile = instBullet.GetComponent<PlayerProjectile>();

            playerProjectile.playerShooting = playerShooting;
        }
    }
}
