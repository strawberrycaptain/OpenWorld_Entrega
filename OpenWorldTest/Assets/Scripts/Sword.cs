using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    public float damage; 

    void OnTriggerEnter(Collider swordcol)
    {
        if(swordcol.gameObject.tag == "Enemy")
        {
            HP enemyHealth = swordcol.gameObject.GetComponent<HP>();
            enemyHealth.health = enemyHealth.health - damage;
        }
    }
}
