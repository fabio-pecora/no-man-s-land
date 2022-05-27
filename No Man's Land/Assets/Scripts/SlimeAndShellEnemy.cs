using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SlimeAndShellEnemy : MonoBehaviour
{
    public Transform Player;
    private NavMeshAgent navMeshAgent;
    public float life;
    public float distance;
    Animator anim;

    void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if(life <= 0) Destroy(this.gameObject);
        if (Player != null)
        {
            distance = (Vector3.Distance(transform.position, Player.position));
            anim.SetBool("isWalking", false);
            anim.SetBool("isAttacking", false);

            // make the enemy move and play the animations if the enemy is close enough
            if (0 <= distance && distance <= 25)
            {
                anim.SetBool("isWalking", true);
                anim.SetBool("isAttacking", false);
                navMeshAgent.destination = Player.position;
                // if out player destroys the enemy or if the enemy wants to attack

                if (distance <= 2)
                {
                    anim.SetBool("isWalking", false);
                    anim.SetBool("isAttacking", true);
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
}