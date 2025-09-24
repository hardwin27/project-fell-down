using UnityEngine;

public class UnitController : MonoBehaviour
{
    [SerializeField] private UnitLogic logic;

    public void Execute(CharacterEntity characterEntity)
    {
        logic.Act(characterEntity);
        Destroy(gameObject);
    }
}
