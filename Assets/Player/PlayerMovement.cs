using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] Camera mainCam;
    [SerializeField] MovementInputs movementInputs;

    Vector3 lastMousePos = Vector3.zero;
    void Update()
    {
        if (movementInputs.Direction != Vector2.zero)
        {
            transform.position += new Vector3(movementInputs.Direction.x, 0, movementInputs.Direction.y) * moveSpeed * Time.deltaTime;
        }
    }
}
