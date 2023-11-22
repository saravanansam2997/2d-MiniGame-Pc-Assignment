using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager mInstance;
    public static GameManager Instance { get { return mInstance; } }
    [SerializeField]
    private GameObject TitleUI, GameUI, GameOverUI;
    [SerializeField]
    private GameObject PlayerObj;
     [SerializeField]
    private ObstacleController ObstacleControllerCS;
    public int ScoreCount=0;
    [SerializeField]
    private TextMeshProUGUI ScoreTxt;
    public bool IsGamePlay = false;
    public bool IsGameOver = false;
    void Awake()
    {
        if (mInstance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            mInstance = this;
        }

    }
    void Start()
    {
        ScoreCount=0;
        IsGameOver = false;
        IsGamePlay=false;
    }
    public void OnPlayClick()
    {
        if(IsGamePlay==false)
        {
        TitleUI.SetActive(false);
        GameOverUI.SetActive(false);
        GameUI.SetActive(true);
        PlayerObj.SetActive(true);
        ObstacleControllerCS.ObstacleControllerStart();
        }
        IsGamePlay = true;
    }
    public void RestartShow()
    {
        GameOverUI.SetActive(true);
        Time.timeScale = 0f;
    }
    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
    public void ScoreCalc(){
      ScoreCount++;
      ScoreTxt.text=ScoreCount.ToString();
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
