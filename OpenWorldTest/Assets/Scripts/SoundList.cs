using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundList : MonoBehaviour
{
    public enum SoundFX
    {
        Attack = 0,
        PlayerDamage,
        Steps
    }

    public GameObject soundControllerPrefab;
    public AudioClip[] sounds;
}
