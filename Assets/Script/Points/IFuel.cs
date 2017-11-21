using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public abstract class IFuel : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        PlayerMoves player = other.gameObject.GetComponentInParent<PlayerMoves>();

        if (player != null)
        {
            ApplyFuel(player);
        }
    }

    public virtual void ApplyFuel(PlayerMoves player)
    {

    }

}
