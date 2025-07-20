FSM State Structure (Boss AI Skeleton)
Basic Finite State Machine structure for a boss

public enum BossState
{
    Idle,
    Chase,
    Attack,
    Rage,
    Stunned,
    Dead
}

public class BossAI : MonoBehaviour
{
    public BossState currentState = BossState.Idle;

    void Update()
    {
        switch (currentState)
        {
            case BossState.Idle:
                HandleIdle();
                break;
            case BossState.Chase:
                HandleChase();
                break;
            case BossState.Attack:
                HandleAttack();
                break;
            case BossState.Rage:
                HandleRage();
                break;
            case BossState.Stunned:
                HandleStunned();
                break;
            case BossState.Dead:
                // do nothing
                break;
        }
    }

    void TransitionTo(BossState newState)
    {
        Debug.Log($"Transition: {currentState} → {newState}");
        currentState = newState;
    }
}


