using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorBullet : MonoBehaviour
{
    public Renderer visual;
    public float time = 4;


    void Start()
    {
        visual.material.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0, 1F));
        Destroy(gameObject, time);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            HP hp = collision.gameObject.GetComponent<HP>();
            hp.health = hp.health - 20;
        }
    }
}
