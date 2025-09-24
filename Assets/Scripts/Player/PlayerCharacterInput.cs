using UnityEngine;

public class PlayerCharacterInput : MonoBehaviour
{
    [SerializeField] private CharacterControlSystem characterControl;

    private void Update()
    {
        characterControl.InputMove(Input.GetAxisRaw("Horizontal"));
    }
}
