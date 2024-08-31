using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    [HideInInspector] public PlayerShooting playerShooting;

    public float Damage;
    public float ProjectileSpeed;

    private void Start()
    {
        playerShooting.projectileMovementBehaviour.Move(this, playerShooting);
    }


    private void OnTriggerEnter(Collider other)
    {
        playerShooting.projectileHitBehaviour.Hit(this, playerShooting, other);
    }



}
