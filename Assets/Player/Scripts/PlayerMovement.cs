using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] MovementInputs movementInputs;

    void Update()
    {
        if (movementInputs.Direction != Vector2.zero)
        {
            transform.position += new Vector3(movementInputs.Direction.x, 0, movementInputs.Direction.y) * moveSpeed * Time.deltaTime;
        }
    }
}
