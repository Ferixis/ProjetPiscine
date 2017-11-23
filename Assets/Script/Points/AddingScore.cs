using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddingScore : IBonus {

    public float pointAdd;

    public override void ApplyBonus(PlayerMoves player)
    {
        player.Collectable(pointAdd);
        AudioManager.Instance.PlayPowerUp();
        Destroy(this.gameObject);
        Debug.Log("POINT UP");
    }
}
