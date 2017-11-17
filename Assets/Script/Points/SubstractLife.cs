using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubstractLife : ICollision
{
    public int lifeLost;
    public bool isDestructible = false;

    public override void ApplyEffect(PlayerMoves player)
    {
        player.TakeDamage(lifeLost);
        Debug.Log("HIt");
    }

    public override void ApplyBulletEffect(Projectile bullet)
    {
        bullet.TakeDamage(1f);

        if(isDestructible)
        {
            Destroy(this.gameObject);
        }
    }
}
