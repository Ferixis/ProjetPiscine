using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Assertions;
using System;
using TMPro;

public class LevelManager : MonoBehaviour {

    // Score //
    
    public TextMeshProUGUI scoreText;

    public float scoreIncrementFrame = 1f ;
    private float actualScore;

    // LevelEnd //

    public GameObject endPanel;
    public TextMeshProUGUI endText, endScoreText;
    //public PlayerMoves player;

    [Header("Tutoriel")]

    public GameObject[] tutorielText;
    public GameObject tutorielHolder;
    private int idx = 0;

    public static LevelManager Instance { get; private set; }

    public TimeSpan RunningTime
    {
        get { return DateTime.UtcNow - _startedTime; }

    }

    private DateTime _startedTime;

    void Awake()
    {
        Assert.IsNotNull(scoreText) ;
        Assert.IsNotNull(endPanel);
        //Assert.IsNotNull(player);
        //Assert.IsNotNull(audioObj);
        Instance = this;

    }
	// Use this for initialization
	void Start () {

        _startedTime = DateTime.UtcNow;
	}



    public void AddGlobalScore (float addScore)
    {
        actualScore += addScore;
        scoreText.text = actualScore.ToString("f0");
        //Debug.Log(actualScore);
    }

    public void LevelEnd (bool isDead)
    {
        //Time.timeScale = 0;
        
        //player.enabled = false;
        //audioObj.SetActive(false);
        if(endPanel != null && !isDead)
        {
            endText.text = "Félicitation !"; 
        }
        else if(endPanel != null && isDead)
        {
            endText.text = "Hors course !";
        }

        endScoreText.text = "Score : " + actualScore.ToString("");
        endPanel.SetActive(true);
    }

    public void NextStepTuto()
    {
        if(!tutorielHolder.activeSelf)
        {
            tutorielHolder.SetActive(true);
        }
        tutorielText[idx].SetActive(false);
        idx++;
        tutorielText[idx].SetActive(true);
    }

    public void UnShowTuto()
    {
        tutorielHolder.SetActive(false);
    }

    public void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}

