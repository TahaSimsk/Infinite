using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Shoot Behaviours/Shoot Around")]
public class ShootAround : ShootBehaviourBaseClass
{
    public float Damage;
    public float FireRate;
    public float ProjectileSpeed;
    public int ConeAngle;
    public int ProjectileCount;

    float timer;

    public override void Shoot(PlayerShooting playerShooting)
    {
        timer += Time.deltaTime;
        if (timer >= FireRate)
        {
            timer = 0;
            float cone = ConeAngle / ProjectileCount;
            for (int i = 0; i < ProjectileCount; i++)
            {

                GameObject instBullet = Instantiate(playerShooting.Projectile, playerShooting.transform.position, Quaternion.identity);


                instBullet.transform.rotation = Quaternion.Euler(0, cone * i,0 );



                PlayerProjectile playerProjectile = instBullet.GetComponent<PlayerProjectile>();

                playerProjectile.playerShooting = playerShooting;
                playerProjectile.Damage = Damage;
                playerProjectile.ProjectileSpeed = ProjectileSpeed;
            }
        }
    }
}
