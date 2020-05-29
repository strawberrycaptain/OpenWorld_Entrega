using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleBullet : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            HP hp = collision.gameObject.GetComponent<HP>();
            hp.health = hp.health - 20;
        }
    }
}
