namespace AdaptiveAI
{
    public enum SkillTier
    {
        Novice,
        Intermediate,
        Expert
    }

    public static class SkillTierClassifier
    {
        public static SkillTier ClassifyPlayerSkill(float averageReactionTime, int playerAccuracy, int dodgeRate)
        {
            if (averageReactionTime < 0.3f && playerAccuracy > 80 && dodgeRate > 70)
            {
                return SkillTier.Expert;
            }
            else if (averageReactionTime < 0.6f && playerAccuracy > 50 && dodgeRate > 40)
            {
                return SkillTier.Intermediate;
            }
            else
            {
                return SkillTier.Novice;
            }
        }
    }
}
