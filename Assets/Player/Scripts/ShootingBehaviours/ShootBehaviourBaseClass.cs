using UnityEngine;


public abstract class ShootBehaviourBaseClass : ScriptableObject
{
    public bool IsNewUpgrade;
    public abstract void Shoot(PlayerShooting playerShooting);
}
