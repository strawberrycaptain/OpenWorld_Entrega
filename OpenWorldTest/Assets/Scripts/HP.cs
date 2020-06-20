using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HP : MonoBehaviour
{
    public float health;


    SoundList soundList;

    public SkinnedMeshRenderer render;

    void Awake()
    {
        soundList = GameObject.FindWithTag("MainCamera").GetComponent<SoundList>();
    }

    public void HealthDown (float damage)
    {
        health = health - damage;


        if (gameObject.tag == "Enemy")
        {
            soundList.PlaySound(SoundList.SoundFX.EnemyDamage);
            StartCoroutine(Flash());
         
        }
            

        if (gameObject.tag == "Player")
            soundList.PlaySound(SoundList.SoundFX.PlayerDamage);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.tag == "Player")
            health = health + 50;

    }

    IEnumerator Flash()
    {
        for (int i = 0; i < 4; i++)
        {
            render.material.EnableKeyword("_EMISSION");
            yield return new WaitForSeconds(0.05f);
            render.material.DisableKeyword("_EMISSION");
            yield return new WaitForSeconds(0.05f);
            //não funciona
        }

    }
}
