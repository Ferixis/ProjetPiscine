using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableSystem : MonoBehaviour
{
    public float itemValue;
    void OnTriggerEnter(Collider other)
    {
        PlayerMoves player = other.gameObject.GetComponentInParent<PlayerMoves>();
        if(player)
        {
            player.Collectable(itemValue);
            Destroy(this.gameObject);
        }
        
    }

}
