using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AddingScore : IBonus {

    public float pointAdd;

    public override void ApplyBonus(PlayerMoves player)
    {
        //GetComponent<AudioSource>().pitch = Random.Range(-0.2f, 0.2f);
       // GetComponent<AudioSource>().Play();
        player.Collectable(pointAdd);
        Destroy(this.gameObject);
        Debug.Log("POINT UP");
    }
}
