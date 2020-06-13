using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    Transform transfPlayer;
    Transform transf;

    public float speedRotation;

    void Awake()
    {
        transf = GetComponent<Transform>();

        GameObject playerGameObject = GameObject.FindWithTag("Player");
        transfPlayer = playerGameObject.GetComponent<Transform>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    void FixedUpdate()
    {
        transf.position = transfPlayer.position;

        float mvtX = Input.GetAxis("Mouse X");
        transf.Rotate(0, mvtX * speedRotation * Time.deltaTime, 0);
    }

}
