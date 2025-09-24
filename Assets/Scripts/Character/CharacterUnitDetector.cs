using System;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class CharacterUnitDetector : MonoBehaviour
{
    public Action<UnitController> OnUnitDetected;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out UnitController unitController))
        {
            OnUnitDetected?.Invoke(unitController);
        }
    }
}
