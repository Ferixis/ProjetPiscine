using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : IBonus,ITakeDamage {

    public int Degats = 1;
    public float obstacleHealth;
    public bool isDestrutible = false;
    public float obstacleValue;


    void OnCollisionEnter(Collision other)
    {

        ITakeDamage player = other.gameObject.GetComponentInParent<ITakeDamage>();
        //Debug.Log(player);

        if (player != null)
        {

            player.TakeDamage(Degats);

        }
    }


    public void TakeDamage(int damage)
    {
        if (isDestrutible)
        {
            obstacleHealth -= 1;
            if (obstacleHealth <= 0)
            {
                LevelManager.Instance.AddGlobalScore(obstacleValue);
                Destroy(this.gameObject);
            }
        }
    }

}
