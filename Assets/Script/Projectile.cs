using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float maxHealth = 100f;
    private float _currentHealth = 0f;


	// Use this for initialization
	void Start () {

        _currentHealth = maxHealth;

	}


    public void TakeDamage(float damage, GameObject instigator) {

        _currentHealth -= damage;


            }

	// Update is called once per frame
	void Update () {
		




	}
}
