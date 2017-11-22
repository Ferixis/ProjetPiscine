using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddingSpeed : IBonus {

    public float speedAmount;

    public override void ApplyBonus(PlayerMoves player)
    {
        player.Boost(speedAmount);
        Destroy(this.gameObject);
        //Debug.Log("POINT UP");
    }
}
