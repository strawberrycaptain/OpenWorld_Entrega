using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEvents : MonoBehaviour
{
    public AI ai;
    public SwordAttack player;
    public ThirdPersonWalk playerDead;

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

    public void Event_SFX4()
    { 
        soundList.PlaySound(SoundList.SoundFX.PlayerAttackSound);
    }

    public void Event_SFX5()
    {
        soundList.PlaySound(SoundList.SoundFX.Spell);
    }

    public void Event_Death()
    {
        ai.Dead();
    }

    public void Event_Death2()
    {
        playerDead.gameOver();
    }
}
