﻿using UnityEngine;
using UnityEngine.UI;
using System;

public class LevelManager : MonoBehaviour {

    private float actualScore;
    public Text scoreText;
    
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

    }

