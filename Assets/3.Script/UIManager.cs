using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager instance = null;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    //점수 추가하는 클래스 점수를 추가하면 자동으로 UI 갱신
    public void AddScore(int score)
    {
        playerScore += score;
        Update_Score_Text(playerScore);
    }


    [SerializeField]
    private TextMeshProUGUI Score_Text;


    [SerializeField]
    private GameObject Gameover_ob;


    private int playerScore = 0;

 

    public void Update_Score_Text(int newScore)
    {
        Score_Text.text = $"Score : {newScore}";

    }

    public void SetActive_GameOver(bool isactive)
    {
        Gameover_ob.SetActive(isactive);
    }
    public void GameRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }


}
