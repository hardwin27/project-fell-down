using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayController : MonoBehaviour
{
    [SerializeField] private CharacterControlSystem playerCharacter;

    public CharacterControlSystem PlayerCharacter { get => playerCharacter; }

    private void Awake()
    {
        Time.timeScale = 0f;
        if (playerCharacter != null)
        {
            playerCharacter.OnDie += HandlePlayerDeath;
        }
    }

    private void Start()
    {
        Time.timeScale = 1f;
    }

    private void HandlePlayerDeath()
    {
        Time.timeScale = 0f;
    }
}
