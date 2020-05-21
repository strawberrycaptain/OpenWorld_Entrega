using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorBullet : MonoBehaviour
{
    public Renderer visual;
    public float time = 5;

    void Start()
    {
        visual.material.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0, 1F));
        Destroy(gameObject, time);
    }
}
