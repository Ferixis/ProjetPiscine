using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ICollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        PlayerMoves player = collision.gameObject.GetComponent<PlayerMoves>();
        Projectile bullet = collision.gameObject.GetComponent<Projectile>();

        if(player)
        {
            ApplyEffect(player);
        }
        else if(bullet)
        {
            ApplyBulletEffect(bullet);
        }
    }

    public virtual void ApplyEffect(PlayerMoves player)
    {

    }

    public virtual void ApplyBulletEffect(Projectile bullet)
    {

    }
}
