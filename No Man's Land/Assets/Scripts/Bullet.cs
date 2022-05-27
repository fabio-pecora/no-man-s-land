using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    static public float damage;
    private void Awake()
    {
        // because the shooting come from the player, so I thought that it was 
        // better to add the damage on the player rather than the projectile
        damage = Jammo.damage;
    }

    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        Shooting._pool.Release(this.gameObject);
    }
}
