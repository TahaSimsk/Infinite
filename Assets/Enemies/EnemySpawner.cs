using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    [SerializeField] float enemySpawnRate;
    [SerializeField] Transform[] enemyPositions;


    private void Start()
    {
        StartCoroutine(SpawnEnemies());
    }




    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            int randomIndex = Random.Range(0, enemyPositions.Length);

            Instantiate(enemy, enemyPositions[randomIndex].position, Quaternion.identity);

            yield return new WaitForSeconds(enemySpawnRate);
        }
    }

}



