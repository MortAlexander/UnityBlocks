using System;
using System.IO;
using UnityEngine;

public class DataContainer : MonoBehaviour
{
    public static DataContainer Instance;
    public String OldName;
    public String Name;
    public int Score=0;
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadName();
    }
    public void SaveName()
    {
        SaveData data = new SaveData();
        data.Name = Name;
        data.Score = Score;

        string json = JsonUtility.ToJson(data);
  
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
    public void LoadName()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            OldName = data.Name;
            Name = data.Name;
            Score = data.Score;
        }
    }
    [System.Serializable]
    class SaveData
    {
        public String Name;
        public int Score;
    }
}
