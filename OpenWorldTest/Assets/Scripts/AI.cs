using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour
{
    public enum StateIA
    {
        Attacking,
        Walking,
        Dead
    }

    public StateIA state;

    NavMeshAgent agent;
    HP hp;
    HP hpPlayer;
    public float damage;

    public Animator animationController;

    SoundList soundList;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        hp = GetComponent<HP>();
        hpPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<HP>();
        soundList = GameObject.FindWithTag("MainCamera").GetComponent<SoundList>();
    }

    void Update()
    {
        if(hp.health > 0)
        {
            if (agent.isStopped)
            {
                state = StateIA.Attacking;
            }
            else
            {
                state = StateIA.Walking;
            }
            animationController.SetFloat("Velocity", agent.velocity.magnitude);
        }

        if (hp.health <= 0)
        {
            agent.isStopped = true;
            //agent.enabled = false;
            state = StateIA.Dead;
            animationController.SetTrigger("Dead");
        }
    }

    public void EnemyAttack()
    {
        hpPlayer.HealthDown(damage);
        soundList.PlaySound(SoundList.SoundFX.EnemyAttack);
    }

    public void Dead()
    {
        Destroy(gameObject, 1.6f);
    }

}
