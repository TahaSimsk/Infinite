using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float maxHealth;

    float currentHealth;

    void Start()
    {
        currentHealth = maxHealth;   
    }

    public bool GetDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth<=0)
        {
            gameObject.SetActive(false);
            return true;
        }
        return false;
    }
}
