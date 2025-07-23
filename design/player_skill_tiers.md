 /design/player_skill_tiers.md
Player Skill Tier Classification
This document defines the criteria for classifying player skill based on dodge success rate and optionally attack accuracy, allowing for adaptive gameplay balancing.

 Purpose
Classifying players enables the AI to adapt difficulty in real time. This supports a dynamic boss design that feels challenging but fair, aligning with the thesis goal of emotionally and mechanically adaptive experiences.

Metrics Used
Dodge Success Rate
successfulDodges / totalDodges

Attack Accuracy (optional)
successfulHits / totalAttacks

Skill Tiers
Tier	Dodge Success Rate	Description
Novice	< 40%	New or struggling players. Likely unfamiliar with patterns or controls.
Intermediate	40% – 70%	Decent awareness of boss patterns and moderate reaction timing.
Experienced	> 70%	Highly reactive, reads patterns well, likely aggressive and confident.

These brackets may evolve after early playtests. Consider logging tier progression over time.

How It's Used
-Skill tier is recalculated every 10–30 seconds (or per boss phase).
-Boss behavior system references this classification to adjust:
    -Attack patterns
    -Telegraphed timing
    -Use of feints or follow-ups
    -Cooldown frequency
Integration point: SkillTierClassifier.cs or PlayerStatsTracker.cs can run tier logic.

📁 Recommended Placement
Design:
/design/player_skill_tiers.md
Code (if implemented):
/player/SkillTierClassifier.cs

🔄 Example Output (Console/Log)
json
Copy
Edit
{
  "timestamp": 45.6,
  "metric": "SkillTierUpdate",
  "tier": "Intermediate",
  "dodgeSuccessRate": 0.55,
  "accuracy": 0.62
}
