using UnityEngine;
using System.IO;

public class Settings : Singleton<Settings>
{
    SettingsData data;
    private int numOfPlayers;

    public int NumOfPlayers { get => numOfPlayers; set => numOfPlayers = value; }

    public void Awake()
    {
        data = new SettingsData();
        data.numOfPlayers = 6;
    }
    
    public void SaveSettings()
    {
        if(!File.Exists(Application.persistentDataPath + "/settings.json")) { File.Create(Application.persistentDataPath + "/settings.json"); }
        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(Application.persistentDataPath + "/settings.json", json);
        Debug.Log("Settings save successfully");
    }

    public void LoadSettings()
    {
        if(!File.Exists(Application.persistentDataPath + "/settings.json")) { File.Create(Application.persistentDataPath + "/settings.json"); }
        try
        {
            string json = File.ReadAllText(Application.persistentDataPath + "/settings.json");
            data = JsonUtility.FromJson<SettingsData>(json);
            Debug.Log("Settings loaded successfully");
        }
        catch
        {
            Debug.LogError("Settings load failed");
        }
    }
    
    public class SettingsData
    {
        public int numOfPlayers;
    }
}
