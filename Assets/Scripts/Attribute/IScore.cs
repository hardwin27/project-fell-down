public interface IScore
{
    int CurrentScore { get; }

    delegate void ScoreEvent();
    event ScoreEvent OnScoreAdjusted;

    void AdjustScore(int value);
}
