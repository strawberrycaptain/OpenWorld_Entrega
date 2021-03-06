﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatBomb : MonoBehaviour
{
    public GameObject fxPrefab;
    Rigidbody rdb;
    public float bombForce = 2;

    private void Start()
    {
        Invoke("Explode", 1f);
    }

    void Explode()
    {
        Instantiate(fxPrefab, transform.position, transform.rotation);
        RaycastHit[] hits;
        hits = Physics.SphereCastAll(transform.position, 5, Vector3.up, 10);

        if (hits.Length > 0)
        {
            foreach (RaycastHit hit in hits)
            {
                if (hit.rigidbody)
                {
                    hit.rigidbody.isKinematic = false;
                    hit.rigidbody.AddExplosionForce(bombForce, transform.position, 10);
                }
            }
        }
        Destroy(gameObject);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            HP hp = collision.gameObject.GetComponent<HP>();
            hp.health = hp.health - 20;
            Invoke("Explode", 1);
        }
    }
}
