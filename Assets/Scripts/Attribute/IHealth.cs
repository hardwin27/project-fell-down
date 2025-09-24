public interface IHealth
{
    int CurrentHealth { get; }

    delegate void HealthEvent();
    event HealthEvent OnHealthAdjusted;
    event HealthEvent OnDie;

    void AdjustHealth(int value);
}
