using System.Collections.Generic;
using UnityEngine;

public class AdaptiveHitTrigger : MonoBehaviour
{
    public BossFSM bossFSM;
    public BossLogger logger;
    public SkillMetricsUI skillMetricsUI; // Reference to the SkillMetricsUI

    
    private List<float> hitTimestamps = new List<float>();
    public float rageWindow = 5.0f;
    public int rageHitThreshold = 3;

    public void RegisterHit(float damage)
    {
        float now = Time.time;
        hitTimestamps.Add(now);

        // Remove hits older than rageWindow
        hitTimestamps.RemoveAll(t => now - t > rageWindow);

        logger?.LogEvent("PlayerHitBoss", "Player", "Boss", now, new Dictionary<string, object>
        {
            {"damage", damage},
            {"recentHits", hitTimestamps.Count}
        });

        // Update skill metrics UI with attack result
        bool didHit = damage > 0; // Assuming a hit means damage is > 0
        skillMetricsUI.RegisterAttack(didHit); // Update attack accuracy


        if (hitTimestamps.Count >= rageHitThreshold)
        {
            bossFSM.TransitionTo(BossState.Rage);
            logger?.LogEvent("AdaptiveTrigger", "System", "BossFSM", now, new Dictionary<string, object>
            {
                {"trigger", "3HitsIn5s"},
                {"action", "EnterRage"}
            });

            hitTimestamps.Clear();
        }
    }
}
