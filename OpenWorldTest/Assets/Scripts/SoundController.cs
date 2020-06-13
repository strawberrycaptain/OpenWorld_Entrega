using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip soundClip;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        audioSource.clip = soundClip;
        audioSource.Play();
        Destroy(gameObject, soundClip.length);
    }
}
