using UnityEngine;

public abstract class ProjectileHitBehaviourBaseClass
{
    public abstract void Hit(PlayerProjectile playerProjectile, PlayerShooting playerShooting, Collider collider);
}

public class DefaultProjectileHit : ProjectileHitBehaviourBaseClass
{
    public override void Hit(PlayerProjectile playerProjectile, PlayerShooting playerShooting, Collider collider)
    {
        EnemyHealth enemyHealth = collider.GetComponent<EnemyHealth>();

        if (enemyHealth == null) return;

        if (enemyHealth.GetDamage(playerProjectile.Damage))
        {
            playerShooting.Scanner.RemoveEnemy(collider.gameObject);
            playerShooting.xpManager.GainXp();
        }

        playerProjectile.gameObject.SetActive(false);
    }

}
