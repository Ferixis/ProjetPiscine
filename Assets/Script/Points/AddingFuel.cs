using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddingFuel : IFuel
{

    public float fuelAmount;

    public override void ApplyFuel(PlayerMoves player)
    {
        player.FuelBoost(fuelAmount);
        Destroy(this.gameObject);
        //Debug.Log("Fuel Up");
    }
}
