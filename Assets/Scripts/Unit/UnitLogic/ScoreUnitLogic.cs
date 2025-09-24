using UnityEngine;

public class ScoreUnitLogic : UnitLogic
{
    
    [SerializeField] private int scoreValue;

    public override void Act(CharacterEntity characterEntity)
    {
        characterEntity.AdjustScore(scoreValue);
    }
}
