using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

//�÷��̾� ������ ���� ������ ���� ��
// �̸��� ���ھ ������ FlaapyBird�� �÷����ϴµ� ������ ����.
[System.Serializable]
public class PlayerData
{
    public string name;
    public int score;
}



//�̱��� �������� ������ ������ �Ŵ��� 
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
        // ���� �÷��̾� ������ ����Ʈ�� �߰�
        // ����Ʈ�� JSON ������ ���ڿ��� ��ȯ�Ͽ� ����
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

        // ����� JSON ������ ���ڿ��� ����Ʈ�� ��ȯ�Ͽ� ��ȯ
        string json = File.ReadAllText(path);
        playerDataList = JsonUtility.FromJson<List<PlayerData>>(json);

        Debug.Log("Player data loaded.");
        return playerDataList;
    }
}
