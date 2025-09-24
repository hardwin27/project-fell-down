using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameplayUi : MonoBehaviour
{
    [SerializeField] private GameplayController gameplayController;

    [SerializeField] private GameObject startPanel;
    [SerializeField] private GameObject inGamePanel;
    [SerializeField] private GameObject endPanel;

    [SerializeField] private Button startButton;

    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI healthText;

    [SerializeField] private TextMeshProUGUI finalScoreText;
    [SerializeField] private Button restartButton;

    private void Awake()
    {
        gameplayController.OnGameInitiated += HandleGameInitiated;
        gameplayController.OnGameStarted += HandleGameStarted;
        gameplayController.OnGameEnded += HandleGameEnded;

        gameplayController.PlayerCharacter.Entity.OnScoreAdjusted += UpdatePlayerScore;
        gameplayController.PlayerCharacter.Entity.OnHealthAdjusted += UpdatePlayerHealth;

        startButton.onClick.AddListener(StartGame);
        restartButton.onClick.AddListener(RestartGame);
    }

    private void StartGame()
    {
        gameplayController.StartGame();
    }

    private void RestartGame()
    {
        gameplayController.RestartGame();
    }
    
    private void HandleGameInitiated()
    {
        startPanel.SetActive(true);
        inGamePanel.SetActive(false);
        endPanel.SetActive(false);
    }

    private void HandleGameStarted()
    {
        startPanel.SetActive(false);
        inGamePanel.SetActive(true);

        UpdatePlayerScore();
        UpdatePlayerHealth();
    }

    private void HandleGameEnded() 
    {
        inGamePanel.SetActive(false);
        endPanel.SetActive(true);
        finalScoreText.text = $"Final Score: {gameplayController.PlayerCharacter.Entity.CurrentScore}";
    }

    private void UpdatePlayerScore()
    {
        scoreText.text = $"Score: {gameplayController.PlayerCharacter.Entity.CurrentScore}";
    }

    private void UpdatePlayerHealth()
    {
        healthText.text = $"Health: {gameplayController.PlayerCharacter.Entity.CurrentHealth}";
    }
}
