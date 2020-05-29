using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IA : MonoBehaviour
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

        if (state == StateIA.Attacking)
        {
            hpPlayer.health = hpPlayer.health - damage * Time.deltaTime;
        }

        if (hp.health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
