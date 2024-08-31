using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public XpManager xpManager;
    public float FireRate;
    public float ProjectileSpeed;
    public TargetScanner Scanner;
    public GameObject Projectile;
    public Transform ProjectileSpawnPoint;
    public float Damage;

    public ShootBehaviourBaseClass shootBehavior;
    public ProjectileMovementBehaviourBaseClass projectileMovementBehaviour;
    public ProjectileHitBehaviourBaseClass projectileHitBehaviour;
    public List<ShootBehaviourBaseClass> shootBehaviours;

    private void Start()
    {
        //shootBehavior = new DefaultShooting();
        projectileMovementBehaviour = new DefaultProjectileMovement();
        projectileHitBehaviour = new DefaultProjectileHit();
    }

    private void Update()
    {
        foreach (var item in shootBehaviours)
        {
            item.Shoot(this);
        }
        //shootBehavior.Shoot(this);
    }

    public void AddBehaviour(ShootBehaviourBaseClass behaviour, bool isNewBehaviour)
    {
        if (isNewBehaviour)
        {
            shootBehaviours.Add(behaviour);

        }
        else
        {
            int index = shootBehaviours.FindIndex(x => x.GetType() == behaviour.GetType());
           
            shootBehaviours[index] = behaviour;

         
        }
    }
}
