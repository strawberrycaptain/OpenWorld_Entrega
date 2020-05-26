using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public float time = 1.5f;
    Rigidbody rdb;

    void Start()
    {
        rdb = GetComponent<Rigidbody>();
        Destroy(gameObject, time);
    }

    void FixedUpdate()
    {
        rdb.AddForce(transform.forward, ForceMode.Impulse);
    }

}
