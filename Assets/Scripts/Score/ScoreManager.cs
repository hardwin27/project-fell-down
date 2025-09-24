using System;
using UnityEngine;
using SingletonSystem;
using Sirenix.OdinInspector;

public class ScoreManager : Singleton<ScoreManager>
{
    [SerializeField, ReadOnly] private int currentScore;
    public int CurrentScore { get => currentScore; }

    public Action OnScoreUpdated;

    public void AddScore(int score)
    {
        currentScore += score;
        OnScoreUpdated?.Invoke();
    }
}
