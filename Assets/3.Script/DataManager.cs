using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

//플레이어 데이터 정보 저장을 위한 것
// 이름과 스코어만 있으면 FlaapyBird를 플레이하는데 문제가 없슴.
[System.Serializable]
public class PlayerData
{
    public string name;
    public int score;
}



//싱글톤 형식으로 구현된 데이터 매니저 
public class DataManager : MonoBehaviour
{
    public static DataManager Instance = null;
    private string path = "SaveData.Json";
    public PlayerData[] totalPlayer;
    private List<PlayerData> playerDataList = new List<PlayerData>();
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(this.gameObject);

    }
    private void Start()
    {
        LoadPlayerData();
    }
    public PlayerData nowPlayer = new PlayerData();

    public Dictionary<string, int> playerScoreDataDict { get; private set; } = new Dictionary<string, int>();

    public void addData(string name, int score)
    {
        nowPlayer.name = name;
        nowPlayer.score = score;
        if (playerScoreDataDict.ContainsKey(name))
        {
            playerScoreDataDict[name] = score;
        }
        else
        {
            playerScoreDataDict.Add(name, score);
        }
        playerDataList.Add(nowPlayer);
        SavePlayerData();
    }

    public void refreshSocre(int score)
    {
        addData(nowPlayer.name, score);
    }

    public void SavePlayerData( )
    {
        // 현재 플레이어 정보를 리스트에 추가
        // 리스트를 JSON 형태의 문자열로 변환하여 저장
        string json = JsonUtility.ToJson(playerDataList);
        File.WriteAllText(path, json);
        Debug.Log(json);
        Debug.Log("Player data saved.");
    }

    public List<PlayerData> LoadPlayerData()
    {
        if (!File.Exists(path))
        {
            Debug.Log("Player data file not found.");
            return null;
        }

        // 저장된 JSON 형태의 문자열을 리스트로 변환하여 반환
        string json = File.ReadAllText(path);
        playerDataList = JsonUtility.FromJson<List<PlayerData>>(json);

        Debug.Log("Player data loaded.");
        return playerDataList;
    }
}
