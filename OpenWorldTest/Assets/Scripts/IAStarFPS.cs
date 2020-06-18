using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IAStarFPS : MonoBehaviour
{
    public GameObject target;
    public NavMeshAgent agent;
    public float minDistance;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    void Update()
    {
        agent.destination = target.transform.position;

        Vector3 LookAtPlayer = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z);

        float distancePlayerEnemy = Vector3.Distance(transform.position, target.transform.position);
        if (distancePlayerEnemy <= minDistance)
        {
            agent.isStopped = true;
        }
        else
        {
            agent.isStopped = false;
        }
    }
}
