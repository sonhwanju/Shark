using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;
using System.Text;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    public InterfaceManager interfaceManager;

    public Dictionary<string, _SharkData> sharks;

    [SerializeField]
    private string datapath;

    void Start()
    {
        datapath = Application.streamingAssetsPath + "/DataFile.json";
        sharks = new Dictionary<string, _SharkData>();
        interfaceManager = gameObject.GetComponent<InterfaceManager>();
        LoadData();
    }

    private void OnApplicationQuit()
    {
        SaveData();
    }

    public void SaveData()
    {
        StringBuilder st = new StringBuilder();
        foreach(string key in sharks.Keys)
        {
            _SharkData shark;
            sharks.TryGetValue(key, out shark);
            st.Append("{\"key\":");
            st.Append("\"");
            st.Append(key);
            st.Append("\"}|");
            st.Append(JsonUtility.ToJson(shark));
            st.Append("\n");
        }
        string json = st.ToString();
        Debug.Log(json);
        byte[] bt = Encoding.UTF8.GetBytes(json);
        if (!File.Exists(datapath))
        {
            File.Create(datapath);
        }
        File.WriteAllBytes(datapath, bt);
    }

    public void LoadData()
    {
        sharks = new Dictionary<string, _SharkData>();
        if (File.Exists(datapath))
        {
            byte[] bt = File.ReadAllBytes(datapath);
            string json = Encoding.UTF8.GetString(bt);
            string[] strs = json.Split('\n');
            for(int i = 0; i < strs.Length - 1; i++)
            {
                string[] kv = strs[i].Split('|');
                string key = kv[0].Substring(8, kv[0].Length - 10);
                _SharkData value = JsonUtility.FromJson<_SharkData>(kv[1]);
                sharks[key] = value;
            }
        }
    }
}
