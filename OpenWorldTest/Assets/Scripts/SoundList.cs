using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundList : MonoBehaviour
{
    public enum SoundFX
    {
        PlayerAttack,
        EnemyAttack,
        PlayerDamage,
        EnemyDamage,
        PlayerJump,
        Steps
    }

    public GameObject soundControllerPrefab;
    public AudioClip[] sounds;

    public void PlaySound(SoundFX sfx)
    {
        GameObject newController = Instantiate<GameObject>(soundControllerPrefab, transform.position, Quaternion.identity);
        SoundController newController_new = newController.GetComponent<SoundController>();

        int soundNumber = (int)sfx;
        AudioClip audioSFX = sounds[soundNumber];

        newController_new.soundClip = audioSFX;
    }
}
