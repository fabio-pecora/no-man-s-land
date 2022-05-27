using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public Transform Player;
    private NavMeshAgent navMeshAgent;
    public float life = 30;
    Animator anim;
    public float distance;
    public static int explosionDamage = 5;
    //public SphereCollider collider;

    void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
       
       
    }

    private void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Player != null)
        {
            distance = (Vector3.Distance(transform.position, Player.position));
            anim.SetBool("isWalking", false);
            anim.SetBool("startAttack", false);

            // make the enemy move and play the animations if the enemy is close enough
            if (distance <= 40)
            {
                anim.SetBool("isWalking", true);
                navMeshAgent.destination = Player.position;
                // if out player destroys the enemy or if the enemy wants to attack

                if (distance <= 5 || life <= 0)
                {
                    anim.SetBool("isWalking", false);
                    anim.SetBool("startAttack", true);
                }
            }
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Projectile")
        {
            life -= Bullet.damage;
            Debug.Log(life);
        }
    }
   
    // destroy the bomb at an exact moment of the animation
    private void suicide()
    {
        Destroy(this.gameObject);
    }

    // play the sound at the exact moment of the animation when the bomb explode
    private void playSound()
    {
        AudioManager.instance.Play("Explosion");
    }
}
