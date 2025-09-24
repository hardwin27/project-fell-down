using System;
using Sirenix.OdinInspector;
using UnityEngine;

public class CharacterControlSystem : MonoBehaviour
{
    [SerializeField] private CharacterEntity entity;
    [SerializeField] private CharacterMovement movement;
    [SerializeField] private CharacterVisual visual;
    [SerializeField] private CharacterUnitDetector unitDetector;

    public Action OnDie;

    public CharacterEntity Entity { get => entity; }

    private void Awake()
    {
        if (unitDetector != null)
        {
            unitDetector.OnUnitDetected += ExecuteUnit;
        }

        if (entity != null)
        {
            entity.OnDie += HandleCharacterDeath;
        }
    }

    public void InputMove(float moveDir)
    {
        movement.InputMove(moveDir);
        visual.ChangeDirection(moveDir);
    }

    private void ExecuteUnit(UnitController unitController)
    {
        unitController.Execute(entity);
    }

    private void HandleCharacterDeath()
    {
        OnDie?.Invoke();
        gameObject.SetActive(false);
    }
}
