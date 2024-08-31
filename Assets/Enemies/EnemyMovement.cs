using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    GameObject player;
    [SerializeField] Vector2 moveSpeed;

    float moveSpeed2;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        moveSpeed2 = Random.Range(moveSpeed.x, moveSpeed.y);
    }

    void Update()
    {
        Vector3 direction = player.transform.position - transform.position;

        transform.position += direction.normalized * moveSpeed2 * Time.deltaTime;
    }
}
