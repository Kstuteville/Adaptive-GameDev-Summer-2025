AdaptiveDifficultyManager difficultyManager;
BossBehaviorController bossController;

void Start()
{
    difficultyManager = FindObjectOfType<AdaptiveDifficultyManager>();
    bossController = GetComponent<BossBehaviorController>();
}

// Call this during reassessment
void UpdateBossBehavior()
{
    SkillTier currentTier = difficultyManager.EvaluatePlayerSkill();
    bossController.AdjustBehavior(currentTier);
}