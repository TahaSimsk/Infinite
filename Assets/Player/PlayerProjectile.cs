using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    [HideInInspector] public PlayerShooting playerShooting;




    private void Start()
    {
        //transform.LookAt(target.transform.position);
        Destroy(gameObject, 1f);
        StartCoroutine(MoveProjectile());
    }

    IEnumerator MoveProjectile()
    {
        transform.LookAt(playerShooting.Scanner.enemiesInRange[0].transform.position);
        Vector3 direction = Vector3.zero;
        while (true)
        {
            direction = transform.forward * playerShooting.ProjectileSpeed * Time.deltaTime;
            direction.y = 0f;
            transform.position += direction;
            yield return null;
        }
    }




    private void OnTriggerEnter(Collider other)
    {

        EnemyHealth enemyHealth = other.GetComponent<EnemyHealth>();

        if (enemyHealth == null) return;

        if (enemyHealth.GetDamage(playerShooting.Damage))
        {
            playerShooting.Scanner.RemoveEnemy(other.gameObject);

        }

        gameObject.SetActive(false);
    }



}
