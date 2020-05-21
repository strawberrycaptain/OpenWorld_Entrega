using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushBullet : MonoBehaviour
{
    public float time=3;
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
