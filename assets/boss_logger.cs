//Handles all event logging in game and outputs them as a structed JSON to the console or a file
using System.Collections.Generic;
using UnityEngine;

public class BossLogger : MonoBehaviour
{
    private List<Dictionary<string, object>> eventLog = new List<Dictionary<string, object>>();

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
