//Handles all event logging in game and outputs them as a structed JSON to the console or a file
using System.Collections.Generic;
using UnityEngine;

public class BossLogger : MonoBehaviour
{

    //track stats
    private int totalAttacks = 0;
    private int successfulHits = 0;

    private int totalDodges = 0;
    private int successfulDodges = 0;


    private List<Dictionary<string, object>> eventLog = new List<Dictionary<string, object>>();
    
    //Register attack
    public void RegisterAttack(bool didHit){
        totalAttacks++;
        if (didHit) successfulHits++;
         LogEvent("PlayerAttack", "Player", "Boss", Time.time, new Dictionary<string, object>
        {
            {"didHit", didHit},
            {"totalAttacks", totalAttacks},
            {"successfulHits", successfulHits},
            {"accuracy", (float)successfulHits / totalAttacks}
        });
    }

    //Register Dodge
    public void RegisterDodge(bool wasSuccessful){
        totalDodges++;
        if (wasSuccessful) successfulDodges++;
         LogEvent("PlayerDodge", "Player", "Boss", Time.time, new Dictionary<string, object>
        {
            {"wasSuccessful", wasSuccessful},
            {"totalDodges", totalDodges},
            {"successfulDodges", successfulDodges},
            {"dodgeSuccessRate", (float)successfulDodges / totalDodges}
        });
    }
    
    
    
    
    //core method to log any event in json
    public void LogEvent(string eventType, string source, string target, float time, Dictionary<string, object> extraData = null)
    {
        var logEntry = new Dictionary<string, object>
        {
            {"eventType", eventType},
            {"source", source},
            {"target", target},
            {"time", time},
            {"data", extraData ?? new Dictionary<string, object>()}
        };

        eventLog.Add(logEntry);
        Debug.Log(JsonUtility.ToJson(new SerializableDictionary(logEntry))); // Console output for now
    }

    // Optional: Save to file later
    public void ExportLogs()
    {
        // Implement if you want to dump to .json
    }
}
