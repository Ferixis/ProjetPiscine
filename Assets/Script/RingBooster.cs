using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingBooster : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        PlayerMoves player = other.gameObject.GetComponentInParent<PlayerMoves>();
        Debug.Log("Boosted");
        if(player)
        {
            player.Boost();
        }
        
    }

}
