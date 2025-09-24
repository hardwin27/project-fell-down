using UnityEngine;

public class HpUnitLogic : UnitLogic
{
    [SerializeField] private int healthValue;

    public override void Act(CharacterEntity characterEntity)
    {
        characterEntity.AdjustHealth(healthValue);
    }
}
