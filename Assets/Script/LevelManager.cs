using UnityEngine;
using UnityEngine.UI;
using System;

public class LevelManager : MonoBehaviour {

    // Score //
    
    public Text scoreText;
    private float actualScore;

    // LevelEnd //

    public GameObject endingBoard;
    public Transform player;
    public GameObject audioObj;

    public static LevelManager Instance { get; private set; }

    public TimeSpan RunningTime
    {
        get { return DateTime.UtcNow - _startedTime; }

    }

    private DateTime _startedTime;

    void Awake()
    {

        Instance = this;
    }
	// Use this for initialization
	void Start () {

        _startedTime = DateTime.UtcNow;
	}
	public void AddGlobalScore (float addScore)
    {
        actualScore += addScore;
        scoreText.text = "Score : " + actualScore.ToString("f0");
        //Debug.Log(actualScore);
    }

    public void LevelEnd ()
    {
        Debug.Log("squalalala");
        Time.timeScale = 0;
        player.GetComponent<PlayerMoves>().enabled = false;
        audioObj.SetActive(false);
        endingBoard.SetActive(true);
    }

    }

