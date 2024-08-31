using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetScanner : MonoBehaviour
{
    public List<GameObject> enemiesInRange = new();

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            enemiesInRange.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            RemoveEnemy(other.gameObject);
        }
    }

    public void RemoveEnemy(GameObject enemy)
    {
        if (enemiesInRange.Contains(enemy))
        {

            enemiesInRange.Remove(enemy);
        }
    }

 
}
