/ai/boss_behavior_by_tier.md
Adaptive Boss Behavior by Player Skill Tier
This document outlines how the boss will modify its behavior dynamically based on the player's current skill classification (Novice, Intermediate, Experienced).

Objective
To make the boss fight feel dynamic, fair, and personalized—neither overwhelming novice players nor boring experienced ones.

Logic: (in rough psedocode:)
if playerSkill == "Novice":
    boss.attackPattern = "Simple"
    boss.recoveryTime = +20%
    boss.attackRate = -30%
    boss.telegraphDuration = +1s
    boss.comboLength = 1
    boss.tauntFrequency = 0

elif playerSkill == "Intermediate":
    boss.attackPattern = "Balanced"
    boss.recoveryTime = normal
    boss.attackRate = normal
    boss.telegraphDuration = 0.5s
    boss.comboLength = 2
    boss.tauntFrequency = occasional

elif playerSkill == "Experienced":
    boss.attackPattern = "Aggressive + Feints"
    boss.recoveryTime = -10%
    boss.attackRate = +25%
    boss.telegraphDuration = 0.3s
    boss.comboLength = 3-4
    boss.tauntFrequency = frequent
    boss.fakeouts = enabled


ai integration:
This logic will live in /ai/BossBehaviorController.cs or tied into BossFSM.cs.
It is called on:
- Tier reassessment intervals
- Boss phase changes
- Major player state changes (e.g. heavy damage taken, power-up acquired)

Design Notes
Feints = attacks with delayed or canceled follow-ups to bait dodges.
Telegraphing = visual/audio warnings before attacks.

Adjusting these in real-time deepens immersion and supports my thesis work on emotionally intelligent AI.

Recommended Placement
Design draft:
/ai/boss_behavior_by_tier.md

Script implementation:
/ai/BossBehaviorController.cs or integrated with FSM system