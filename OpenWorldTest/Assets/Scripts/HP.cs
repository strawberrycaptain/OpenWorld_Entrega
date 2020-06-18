using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HP : MonoBehaviour
{
    public float health;

    public SoundList.SoundFX damageSoundFx;
    SoundList soundList;

    void Awake()
    {
        soundList = GameObject.FindWithTag("MainCamera").GetComponent<SoundList>();
    }

    public void HealthDown (float damage)
    {
        health = health - damage;

        soundList.PlaySound(damageSoundFx);

    }
}
