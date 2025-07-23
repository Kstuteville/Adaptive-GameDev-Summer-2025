using UnityEngine;

public enum BossState
{
    Idle,
    Chase,
    Attack,
    Rage,
    Stunned,
    Dead
}

public class BossFSM : MonoBehaviour
{
    public BossState currentState = BossState.Idle;
    public BossLogger logger;

    void Update()
    {
        switch (currentState)
        {
            case BossState.Idle: HandleIdle(); break;
            case BossState.Chase: HandleChase(); break;
            case BossState.Attack: HandleAttack(); break;
            case BossState.Rage: HandleRage(); break;
            case BossState.Stunned: HandleStunned(); break;
            case BossState.Dead: break;
        }
    }

    void TransitionTo(BossState newState)
    {
        logger?.LogEvent("BossStateChange", "BossFSM", "Boss", Time.time, new Dictionary<string, object>
        {
            {"fromState", currentState.ToString()},
            {"toState", newState.ToString()}
        });

        currentState = newState;
    }

    // Define your state behaviors below
    void HandleIdle() { /* TODO */ }
    void HandleChase() { /* TODO */ }
    void HandleAttack() { /* TODO */ }
    void HandleRage() { /* TODO */ }
    void HandleStunned() { /* TODO */ }
}
