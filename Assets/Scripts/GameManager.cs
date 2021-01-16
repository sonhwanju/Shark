using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;
using System.Text;
using UnityEngine;
using DG.Tweening;

public class GameManager : MonoSingleton<GameManager>
{
    public InterfaceManager interfaceManager; // 인터페이스 매니저
    public Touch touch; // 터치 체크
    public bool isSea = false;

    public Money money;
    public DowNum downum;
    public Dictionary<string, _SharkData> sharks; // 상어 딕셔너리
    public Dictionary<string, Sprite> sprites; // 이미지 딕셔너리
    public Dictionary<string, _Food> foods; // 음식 딕셔너리
    public Dictionary<string, _WaterQuality> waterquality_parts; // 수질 딕셔너리
    public Dictionary<string, _Oxygen> oxygen_parts; // 산소 딕셔너리
    public Dictionary<string, _Volume> volume_parts; // 용량 딕셔너리
    public WaterTank[] watertank = new WaterTank[2]; // 수조

    [SerializeField]
    private string datapath; //불러오기 위치
    [SerializeField]
    private string spritepath; // 이미지 데이터 위치

    void Start()
    {
        Screen.orientation = ScreenOrientation.Landscape;
        Screen.fullScreen = true;
        datapath = Application.streamingAssetsPath; // 위치 지정
        spritepath = Application.dataPath + "/Sprites";
        touch = GetComponent<Touch>(); // 터치 초기화
        interfaceManager = GetComponent<InterfaceManager>(); // 인터페이스 초기화
        LoadData();
    }

    private void OnApplicationQuit()
    {
        SaveData();
    }

    public void SaveData() 
    {
        if (!File.Exists(datapath + "/SaveFile.json"))
        {
            File.Create(datapath + "/SaveFile.json");
        }

        StringBuilder st = new StringBuilder();

        for (int i = 0; i < watertank.Length; i++) // 수조 저장
        {
            st.Append(JsonUtility.ToJson(watertank[i]));
            st.Append("\n");
        }
        st.Append("$\n");
        foreach (string key in foods.Keys) // 먹이 저장
        {
            _Food fd;
            foods.TryGetValue(key, out fd);
            st.Append("{\"key\":\"");
            st.Append(key);
            st.Append("\"}|");
            st.Append(JsonUtility.ToJson(fd));
            st.Append("\n");
        }
        st.Append("$\n");
        foreach (string key in waterquality_parts.Keys) // 먹이 저장
        {
            _WaterQuality fd;
            waterquality_parts.TryGetValue(key, out fd);
            st.Append("{\"key\":\"");
            st.Append(key);
            st.Append("\"}|");
            st.Append(JsonUtility.ToJson(fd));
            st.Append("\n");
        }
        st.Append("$\n");
        foreach (string key in oxygen_parts.Keys) // 먹이 저장
        {
            _Oxygen fd;
            oxygen_parts.TryGetValue(key, out fd);
            st.Append("{\"key\":\"");
            st.Append(key);
            st.Append("\"}|");
            st.Append(JsonUtility.ToJson(fd));
            st.Append("\n");
        }
        st.Append("$\n");
        foreach (string key in volume_parts.Keys) // 먹이 저장
        {
            _Volume fd;
            volume_parts.TryGetValue(key, out fd);
            st.Append("{\"key\":\"");
            st.Append(key);
            st.Append("\"}|");
            st.Append(JsonUtility.ToJson(fd));
            st.Append("\n");
        }
        st.Append("$\n");
        st.Append(JsonUtility.ToJson(money));
        st.Append("|");
        st.Append(JsonUtility.ToJson(downum));
        st.Append("\n");
        byte[] bt = Encoding.UTF8.GetBytes(st.ToString());
        File.WriteAllBytes(datapath + "/SaveFile.json", bt);
    }

    public void LoadData() // 상어 데이터 불러오기
    {
        sharks = new Dictionary<string, _SharkData>();
        foods = new Dictionary<string, _Food>();
        sprites = new Dictionary<string, Sprite>();
        waterquality_parts = new Dictionary<string, _WaterQuality>();
        oxygen_parts = new Dictionary<string, _Oxygen>();
        volume_parts = new Dictionary<string, _Volume>();
        money = new Money();
        downum = new DowNum();
        if (File.Exists(datapath + "/DataFile.json")) // 상어 데이터
        {
            byte[] bt = File.ReadAllBytes(datapath + "/DataFile.json");
            string json = Encoding.UTF8.GetString(bt);
            string[] strs = json.Split('\n'); 
            for (int i = 0; i < strs.Length - 1; i++)
            {
                string[] kv = strs[i].Split('|');
                string key = kv[0].Substring(8, kv[0].Length - 10);
                _SharkData value = JsonUtility.FromJson<_SharkData>(kv[1]);
                sharks[key] = value;
                LoadSprite(key, value.image);
            }
        }
        if (File.Exists(datapath + "/SaveFile.json")) // 수조 & 음식 데이터
        {
            byte[] bt = File.ReadAllBytes(datapath + "/SaveFile.json");
            string json = Encoding.UTF8.GetString(bt);
            string[] strs = json.Split('$');
            string[] tank = strs[0].Split('\n');
            for (int i = 0; i < tank.Length - 1; i++)
            {
                watertank[i] = JsonUtility.FromJson<WaterTank>(tank[i]);
            }
            string[] food = strs[1].Split('\n');
            for (int i = 1; i < food.Length - 1; i++)
            {
                string[] kv = food[i].Split('|'); 
                string key = kv[0].Substring(8, kv[0].Length - 10);
                _Food value = JsonUtility.FromJson<_Food>(kv[1]);
                foods[key] = value;
                LoadSprite(key, value.image);
            }
            string[] wqs = strs[2].Split('\n');
            for (int i = 1; i < wqs.Length - 1; i++)
            {
                string[] kv = wqs[i].Split('|'); 
                string key = kv[0].Substring(8, kv[0].Length - 10);
                _WaterQuality value = JsonUtility.FromJson<_WaterQuality>(kv[1]);
                waterquality_parts[key] = value;
                LoadSprite(key, value.image);
            }
            string[] oxs = strs[3].Split('\n');
            for (int i = 1; i < oxs.Length - 1; i++)
            {
                string[] kv = oxs[i].Split('|'); 
                string key = kv[0].Substring(8, kv[0].Length - 10);
                _Oxygen value = JsonUtility.FromJson<_Oxygen>(kv[1]);
                oxygen_parts[key] = value;
                LoadSprite(key, value.image);
            }
            string[] vos = strs[4].Split('\n');
            for (int i = 1; i < vos.Length - 1; i++)
            {
                string[] kv = vos[i].Split('|'); 
                string key = kv[0].Substring(8, kv[0].Length - 10);
                _Volume value = JsonUtility.FromJson<_Volume>(kv[1]);
                volume_parts[key] = value;
                LoadSprite(key, value.image);
            }
            string[] costs = strs[5].Split('\n');
            for (int i = 1; i < costs.Length - 1; i++)
            {
                string[] kv = costs[i].Split('|'); 
                money = JsonUtility.FromJson<Money>(kv[0]);
                downum = JsonUtility.FromJson<DowNum>(kv[1]);
            }
        }
    }

    public void ResetData()
    {
        if (File.Exists(datapath + "/DefaultSaveFile.json"))
        {
            byte[] bt = File.ReadAllBytes(datapath + "/DefaultSaveFile.json");
            if (!(File.Exists(datapath + "/SaveFile.json")))
                File.Create(datapath + "/SaveFile.json");
            File.WriteAllBytes(datapath + "/SaveFile.json", bt);
        }
        LoadData();
    }

    private void LoadSprite(string key, string filename)
    {
        if (File.Exists(spritepath + "/" + filename))
        {
            Sprite tempsp = (Sprite)Resources.Load(spritepath + "/" + filename);
            sprites[key] = tempsp;
        }
    } // 이미지 불러오기
}
