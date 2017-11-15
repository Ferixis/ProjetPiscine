﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour {

    public int Degats = 1;
    public float obstacleHealth;
    public bool isDestrutible = false;
    public float obstacleValue;
    private float scoreAdded;



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    void OnCollisionEnter(Collision other)
    {

        ITakeDamage player = other.gameObject.GetComponentInParent<ITakeDamage>();
        Debug.Log(player);

        if (player != null)
        {

            player.TakeDamage(Degats);

        }
        else if(other.gameObject.tag == "Bullet" && isDestrutible)
        {
            obstacleHealth -= 1;
            if(obstacleHealth <= 0)
            {
                scoreAdded = obstacleValue;
                LevelManager.Instance.AddGlobalScore(scoreAdded);
                Destroy(this.gameObject);
            }
        }
    }

}
