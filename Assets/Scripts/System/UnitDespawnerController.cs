using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class UnitDespawnerController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out UnitController unitController))
        {
            Destroy(collision.gameObject);
        }
    }
}
