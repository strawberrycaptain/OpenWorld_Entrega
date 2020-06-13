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
    }

    public StateIA state;
    NavMeshAgent agent;
    HP hp;
    HP hpPlayer;
    public float damage;
    public Animator animationController;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        hp = GetComponent<HP>();
        hpPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<HP>();
    }

    private void Update()
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

        if (hp.health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void EnemyAttack()
    {
        hpPlayer.health = hpPlayer.health - damage;
    }
}
