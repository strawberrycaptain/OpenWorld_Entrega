using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyBomb : MonoBehaviour
{

    public float bombForce=1000;
    public GameObject fxPrefab;
    Rigidbody rdb;

    void Start()
    {
        rdb = GetComponent<Rigidbody>();
        Invoke("Explode", 3);
    }

    void Explode()
    {
        Instantiate(fxPrefab, transform.position, transform.rotation);
        Destroy(gameObject);
        RaycastHit[] hits;
        hits=Physics.SphereCastAll(transform.position, 5, Vector3.up, 10);

        if (hits.Length > 0)
        {
            foreach(RaycastHit hit in hits)
            {
                if (hit.rigidbody)
                {
                    hit.rigidbody.isKinematic = false;
                    hit.rigidbody.AddExplosionForce(bombForce, transform.position, 10);
                }
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        rdb.isKinematic = true;
    }

}
