using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour {

    public int Degats = 1;

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

        if(player !=null)
        {

            player.TakeDamage(Degats);

        }

       
           
    }

    }
