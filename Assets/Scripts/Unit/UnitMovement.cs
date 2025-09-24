using UnityEngine;

public class UnitMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D body;
    [SerializeField] private float moveSpeed;

    private void FixedUpdate()
    {
        body.linearVelocityY = -moveSpeed;
    }
}
