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

    public GameObject GetTarget()
    {

        if (enemiesInRange.Count != 0)
        {
            if (enemiesInRange[0] == null)
            {
                enemiesInRange.RemoveAt(0);
            }
            if (enemiesInRange.Count != 0)
            {
                return enemiesInRange[0];
            }
        }
        return null;
    }
}
