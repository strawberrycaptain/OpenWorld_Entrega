using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lifetime : MonoBehaviour
{
    public float time = 6;

    void Start()
    {

    Destroy(gameObject, time);

    }
}
