﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceBullets : MonoBehaviour
{
    Rigidbody rdb;

    void Start()
    {
        rdb = GetComponent<Rigidbody>();
        StartCoroutine(Drop());
    }
    void FixedUpdate()
    {
        rdb.AddForce(transform.up, ForceMode.Impulse);
    }
    IEnumerator Drop()
    {
        yield return new WaitForSeconds(2);

        rdb.useGravity = true;

    }

    private void OnCollisionEnter(Collision collision)
    {
      

        
    }

}

