using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Assertions;
using System;
using TMPro;

public class LevelManager : MonoBehaviour {

    // Score //
    
    public TextMeshProUGUI scoreText;
    private float actualScore;

    // LevelEnd //

    public GameObject endingBoard;
    public PlayerMoves player;
    public GameObject audioObj;
    //public int[] sceneToLoad;

    public static LevelManager Instance { get; private set; }

    public TimeSpan RunningTime
    {
        get { return DateTime.UtcNow - _startedTime; }

    }

    private DateTime _startedTime;

    void Awake()
    {
        Assert.IsNotNull(scoreText) ;
        Assert.IsNotNull(endingBoard);
        Assert.IsNotNull(player);
        Assert.IsNotNull(audioObj);
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

    public void LevelEnd ()
    {
        Debug.Log("squalalala");
        Time.timeScale = 0;
        player.enabled = false;
        audioObj.SetActive(false);
        if(endingBoard != null)
        {
            endingBoard.SetActive(true);
        }
        
        //SceneManager.LoadScene();
    }

    }

