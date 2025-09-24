using UnityEngine;
using Sirenix.OdinInspector;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D body;
    [SerializeField] private float moveSpeed;
    [SerializeField, ReadOnly] private float moveDirection;

    public void InputMove(float direction)
    {
        moveDirection = direction;
    }

    private void FixedUpdate()
    {
        float move = moveDirection * moveSpeed;
        body.linearVelocityX = move;
    }
}
