using Sirenix.OdinInspector;
using UnityEngine;

public class CharacterEntity : MonoBehaviour, IHealth, IScore
{
    [SerializeField] private int startingHealth;
    [SerializeField, ReadOnly] private int currentHealth;
    [SerializeField, ReadOnly] private int currentScore;

    public int CurrentHealth => currentHealth;
    public int CurrentScore => currentScore;

    public event IHealth.HealthEvent OnHealthAdjusted;
    public event IScore.ScoreEvent OnScoreAdjusted;
    public event IHealth.HealthEvent OnDie;

    private void Start()
    {
        AdjustHealth(startingHealth);
    }

    public void AdjustHealth(int value)
    {
        currentHealth += value;
        OnHealthAdjusted?.Invoke();

        if (currentHealth <= 0)
        {
            OnDie?.Invoke();
        }
    }

    public void AdjustScore(int value)
    {
        currentScore += value;
        OnScoreAdjusted?.Invoke();
    }
}
