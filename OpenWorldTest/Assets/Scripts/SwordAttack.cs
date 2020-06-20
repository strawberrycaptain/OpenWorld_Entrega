using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    public float damage;

    //Dano no inimigo com a espada
    void OnTriggerEnter(Collider swordcol)
    {
        if (swordcol.gameObject.tag == "Enemy")
        {
            HP enemyHealth = swordcol.gameObject.GetComponent<HP>();
            enemyHealth.HealthDown(damage);
        }
    }
}
