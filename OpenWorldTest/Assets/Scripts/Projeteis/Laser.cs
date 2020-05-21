using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public float time = 1.5f;
    public GameObject fxPrefab;
    Rigidbody rdb;

    void Start()
    {
        rdb = GetComponent<Rigidbody>();
        Instantiate(fxPrefab, transform.position, transform.rotation);
        Destroy(gameObject, time);
    }

    void FixedUpdate()
    {
        rdb.AddForce(transform.forward, ForceMode.Impulse);
    }

}
