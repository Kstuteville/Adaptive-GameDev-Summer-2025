//in unity have to create UI element in order to use this script

//HOW TO CONNECT TO GAME
//1. In Unity, attach the SkillMetricsUI.cs script to an empty GameObject in your scene, such as SkillMetricsController.
//2.In the Inspector, drag the AccuracyText and DodgeText UI elements to the corresponding fields in the SkillMetricsUI script component.
//3. If the BossLogger is managing the attack/dodge stats, drag the BossLogger component from your LoggerTest GameObject into the bossLogger field in the SkillMetricsUI script component.

//to test 
//Now, whenever you simulate hits or dodges in your game (using RegisterAttack(true/false) or RegisterDodge(true/false)), the UI will update in real-time.
//You should see Accuracy and Dodge Success displayed on the screen, based on the player’s actions.
using UnityEngine;
using UnityEngine.UI;

public class SkillMetricsUI : MonoBehaviour
{
    public Text accuracyText;    // Reference to the Accuracy Text UI element
    public Text dodgeText;       // Reference to the Dodge Success Text UI element

    private int totalAttacks = 0;
    private int successfulHits = 0;
    private int totalDodges = 0;
    private int successfulDodges = 0;

    // Reference to the BossLogger (or other system managing player stats)
    public BossLogger bossLogger;

    void Start()
    {
        // You can initialize or set references if needed
        // Example: Initialize total stats if starting from scratch
    }

    void Update()
    {
        // Update skill stats every frame
        UpdateSkillUI();
    }

    // Update the skill metrics UI
    void UpdateSkillUI()
    {
        // Calculate the accuracy and dodge rate
        float accuracy = totalAttacks > 0 ? (float)successfulHits / totalAttacks : 0f;
        float dodgeRate = totalDodges > 0 ? (float)successfulDodges / totalDodges : 0f;

        // Update the UI text with calculated values
        accuracyText.text = "Accuracy: " + (accuracy * 100).ToString("F1") + "%";
        dodgeText.text = "Dodge Success: " + (dodgeRate * 100).ToString("F1") + "%";
    }

    // Call these methods whenever stats are updated (e.g., from BossLogger or gameplay systems)
    public void RegisterAttack(bool didHit)
    {
        totalAttacks++;
        if (didHit) successfulHits++;
    }

    public void RegisterDodge(bool wasSuccessful)
    {
        totalDodges++;
        if (wasSuccessful) successfulDodges++;
    }
}
