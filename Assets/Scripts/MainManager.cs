using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class MainManager : MonoBehaviour
{
    // Start is called before the first frame update

    public static MainManager Instance;
    public Color TeamColor;
    // Update is called once per frame
    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        LoadColor();
        DontDestroyOnLoad(gameObject);
    }
    [System.Serializable]
    class SaveData
    {
        public Color TeamColor;
    }
    public void SaveColor()
    {
        SaveData data = new SaveData();
        data.TeamColor = TeamColor;
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
    public void LoadColor()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            TeamColor = data.TeamColor;
        }
    }
}
