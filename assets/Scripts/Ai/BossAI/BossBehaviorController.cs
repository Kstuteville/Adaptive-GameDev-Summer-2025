using UnityEngine;

public class BossBehaviorController : MonoBehaviour
{
    public enum AttackPattern { Simple, Balanced, AggressiveFeints }

    [Header("Boss Behavior")]
    public AttackPattern attackPattern;
    public float recoveryTimeModifier = 1.0f;
    public float attackRateModifier = 1.0f;
    public float telegraphDuration = 0.5f;
    public int comboLength = 1;
    public float tauntFrequency = 0f;
    public bool fakeoutsEnabled = false;

    private AdaptiveDifficultyManager difficultyManager;

    void Start()
    {
        difficultyManager = FindObjectOfType<AdaptiveDifficultyManager>();
        AdjustBehaviorBasedOnTier();
    }

    void AdjustBehaviorBasedOnTier()
    {
        if (difficultyManager != null)
        {
            SkillTier tier = difficultyManager.GetCurrentSkillTier();
            AdjustBehavior(tier);
        }
        else
        {
            Debug.LogWarning("AdaptiveDifficultyManager not found in scene.");
        }
    }

    public void AdjustBehavior(SkillTier playerSkill)
    {
        switch (playerSkill)
        {
            case SkillTier.Novice:
                attackPattern = AttackPattern.Simple;
                recoveryTimeModifier = 1.2f;     // +20%
                attackRateModifier = 0.7f;       // -30%
                telegraphDuration = 1.0f;
                comboLength = 1;
                tauntFrequency = 0f;
                fakeoutsEnabled = false;
                break;

            case SkillTier.Intermediate:
                attackPattern = AttackPattern.Balanced;
                recoveryTimeModifier = 1.0f;
                attackRateModifier = 1.0f;
                telegraphDuration = 0.5f;
                comboLength = 2;
                tauntFrequency = 0.3f;
                fakeoutsEnabled = false;
                break;

            case SkillTier.Expert:
                attackPattern = AttackPattern.AggressiveFeints;
                recoveryTimeModifier = 0.9f;     // -10%
                attackRateModifier = 1.25f;      // +25%
                telegraphDuration = 0.3f;
                comboLength = 3;
                tauntFrequency = 0.7f;
                fakeoutsEnabled = true;
                break;
        }

        Debug.Log($"[BossBehaviorController] Adjusted for {playerSkill} player.");
    }
}
