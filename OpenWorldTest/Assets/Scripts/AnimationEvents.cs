using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEvents : MonoBehaviour
{
    public AI ai;
    public Sword player;

    SoundList soundList;

    void Awake()
    {
        soundList = GameObject.FindWithTag("MainCamera").GetComponent<SoundList>();
    }

    public void Event_EnemyAttack()
    {
        ai.EnemyAttack();
    }

    public void Event_SFX()
    {
        soundList.PlaySound(SoundList.SoundFX.Steps);
    }

    public void Event_SFX2()
    {
        soundList.PlaySound(SoundList.SoundFX.PlayerAttack);
    }

    public void Event_SFX3()
    {
        soundList.PlaySound(SoundList.SoundFX.PlayerJump);
    }

}
