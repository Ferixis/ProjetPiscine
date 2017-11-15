using UnityEngine;
using System;



public class LevelManager : MonoBehaviour {

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
	
    }

