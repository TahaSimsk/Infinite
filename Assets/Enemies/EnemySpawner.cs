using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    [SerializeField] float enemySpawnRate;
    [SerializeField] float distanceToSpawn;
    [SerializeField] float x;
    [SerializeField] float y;
    [SerializeField] Camera mainCam;
    [SerializeField] Transform playerPos;
    [SerializeField] Transform[] enemyPositions;
    float timer;

    private void Start()
    {
       // StartCoroutine(SpawnAsteroid());
       StartCoroutine(SpawnEnemies());

    }
    //void Update()
    //{
    //    timer += Time.deltaTime;
    //    if (timer >= enemySpawnRate)
    //    {
    //        Vector3 pos = mainCam.ViewportToWorldPoint(new Vector3(x, y, distanceToSpawn));
    //        Instantiate(enemy, pos, Quaternion.identity);
    //        timer = 0;
    //    }
    //}

    IEnumerator SpawnAsteroid()
    {
        while (true)
        {

            int side = Random.Range(0, 4);

            Vector2 spawnPoint = Vector2.zero;
            switch (side)
            {
                case 0: //left
                    spawnPoint.x = 0f;
                    spawnPoint.y = Random.value;
                    break;

                case 1: //right
                    spawnPoint.x = 1f;
                    spawnPoint.y = Random.value;
                    break;

                case 2: //bottom
                    spawnPoint.x = Random.value;
                    spawnPoint.y = 0f;
                    break;

                case 3: //top
                    spawnPoint.x = Random.value;
                    spawnPoint.y = 1f;
                    break;
            }

            Vector3 worldSpawnPoint = mainCam.ScreenToWorldPoint(spawnPoint);
            worldSpawnPoint.y = 0.5f;
            Instantiate(enemy, worldSpawnPoint, Quaternion.identity);
            Debug.Log(worldSpawnPoint);
            yield return new WaitForSeconds(enemySpawnRate); 
        }
    }

    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            int randomIndex=Random.Range(0, enemyPositions.Length);

            Instantiate(enemy, enemyPositions[randomIndex].position, Quaternion.identity);
          
            yield return new WaitForSeconds(enemySpawnRate);
        }
    }

}

   

