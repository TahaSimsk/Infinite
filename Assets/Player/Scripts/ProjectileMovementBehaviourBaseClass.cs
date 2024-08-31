using System.Collections;
using UnityEngine;

public abstract class ProjectileMovementBehaviourBaseClass
{
    public abstract void Move(PlayerProjectile playerProjectile, PlayerShooting playerShooting);
}

public class DefaultProjectileMovement : ProjectileMovementBehaviourBaseClass
{
    public override void Move(PlayerProjectile playerProjectile, PlayerShooting playerShooting)
    {
        playerProjectile.StartCoroutine(MoveProjectile(playerProjectile, playerShooting));
    }

    IEnumerator MoveProjectile(PlayerProjectile playerProjectile, PlayerShooting playerShooting)
    {
        Object.Destroy(playerProjectile.gameObject, 1f);
        Vector3 direction = Vector3.zero;
        while (true)
        {
            direction = playerProjectile.transform.forward * playerProjectile.ProjectileSpeed* Time.deltaTime;
            direction.y = 0f;
            playerProjectile.transform.position += direction;
            yield return null;
        }
    }
}
