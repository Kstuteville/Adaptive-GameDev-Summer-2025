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

    public float bossHealth = 100f;
    public float maxHealth = 100f;
    public float fightStateTime;
    public Transform player;
    public float distanceToPlayer;

    public float rageThreshold =0.3f; // Enters rage below 30% health
    public float stunnedThreshold = 0.7f; //May get stunned above 70% health and under stress


    void Start(){
        fightStateTime = Time.time;
    }

    void Update()
    {
        distanceToPlayer = Vector3.Distance(transform.position, player.position);
        EvaluateState(); // Evaluate metrics to update phase
        HandleState();   // Act based on current state
    }

    void EvaluateState()
    {
        if (bossHealth <= 0 && currentState != BossState.Dead)
        {
            TransitionTo(BossState.Dead);
            return;
        }

        // Rage logic
        if (bossHealth / maxHealth <= rageThreshold && currentState != BossState.Rage)
        {
            TransitionTo(BossState.Rage);
            return;
        }

        // Stunned logic (example: if far from player or under stress)
        if (bossHealth / maxHealth >= stunnedThreshold && distanceToPlayer > 15f && currentState != BossState.Stunned)
        {
            TransitionTo(BossState.Stunned);
            return;
        }

        // Proximity-based transitions
        if (distanceToPlayer <= 5f && currentState != BossState.Attack)
        {
            TransitionTo(BossState.Attack);
        }
        else if (distanceToPlayer <= 20f && currentState != BossState.Chase && currentState != BossState.Attack)
        {
            TransitionTo(BossState.Chase);
        }
        else if (distanceToPlayer > 20f && currentState != BossState.Idle)
        {
            TransitionTo(BossState.Idle);
        }
    }

    void HandleState()
    {
        switch (currentState)
        {
            case BossState.Idle: HandleIdle(); break;
            case BossState.Chase: HandleChase(); break;
            case BossState.Attack: HandleAttack(); break;
            case BossState.Rage: HandleRage(); break;
            case BossState.Stunned: HandleStunned(); break;
            case BossState.Dead: HandleDeath(); break;
        }
    }

    void TransitionTo(BossState newState)
    {
        logger?.LogEvent("BossStateChange", "BossFSM", "Boss", Time.time, new Dictionary<string, object>
        {
            {"fromState", currentState.ToString()},
            {"toState", newState.ToString()},
            {"healthPercent", bossHealth / maxHealth},
            {"distanceToPlayer", distanceToPlayer}
        });

        currentState = newState;
    }

    // Placeholder behaviors
    void HandleIdle() => Debug.Log("Boss is idling...");
    void HandleChase() => Debug.Log("Boss is chasing the player...");
    void HandleAttack() => Debug.Log("Boss is attacking!");
    void HandleRage() => Debug.Log("Boss has entered rage mode!");
    void HandleStunned() => Debug.Log("Boss is stunned!");
    void HandleDeath() => Debug.Log("Boss is dead.");
}

//next steps 
/*
You can later expand this by:

Connecting health to a real health system (BossHealth.cs)

Adding behavior in each handler (attacks, dashes, etc.)

Logging more contextual data (e.g., player damage rate)

Using Unity Events to hook animations or SFX
*/
