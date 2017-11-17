using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public abstract class IBonus : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        PlayerMoves player = other.gameObject.GetComponentInParent<PlayerMoves>();

        if(player != null)
        {
            ApplyBonus(player);
        }
    }

    public virtual void ApplyBonus(PlayerMoves player)
    {
        
    }

}
