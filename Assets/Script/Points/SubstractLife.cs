using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubstractLife : ICollision
{
    public int lifeLost;
    public float pointGet = 20f;
    public bool isDestructible = false;
    public GameObject explosionEffect;

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
            if(AudioManager.Instance != null)
            {
                AudioManager.Instance.PlayExplosion();
            }
            LevelManager.Instance.AddGlobalScore(pointGet);
            Instantiate(explosionEffect, transform.position, transform.rotation);
            Destroy(this.gameObject);
        }
    }
}
