using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayController : MonoBehaviour
{
    [SerializeField] private CharacterControlSystem playerCharacter;

    public Action OnGameInitiated;
    public Action OnGameStarted;
    public Action OnGameEnded;

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
        OnGameInitiated?.Invoke();
    }

    private void HandlePlayerDeath()
    {
        Time.timeScale = 0f;
        OnGameEnded?.Invoke();
    }

    public void StartGame()
    {
        Time.timeScale = 1f;
        OnGameStarted?.Invoke();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
