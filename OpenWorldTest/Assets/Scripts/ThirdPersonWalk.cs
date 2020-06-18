using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonWalk : MonoBehaviour
{
    public float speedMovement;
    public float jumpForce;
    public float heightDispl;
    public LayerMask layerGround;
    public Animator animator;

    Transform transf;
    Transform transfCam;
    Rigidbody rb;

    //estados

    public bool isGrounded;
    public bool isJumping;
    public bool isWalking;

    public CapsuleCollider swordCollider;

    public static Vector3 groundPoint;

    void Awake()
    {
        transf = GetComponent<Transform>();
        transfCam = GameObject.FindWithTag("CameraPos").GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();
        swordCollider.enabled = false;
    }

    void FixedUpdate()
    {

        bool jumpPress = Input.GetButtonDown("Jump");
        bool attackPress = Input.GetButtonDown("Fire1");
        //bool spellPress = Input.GetButtonDown("Fire2");

        float mvtHor = Input.GetAxis("Horizontal");
        float mvtVer = Input.GetAxis("Vertical");

        Vector3 mvt = new Vector3(mvtHor, 0, mvtVer);

        if (mvt.magnitude > 1f)
            mvt.Normalize();

        //magnitude - length vector

        RaycastHit groundHit;
        isGrounded = Physics.Raycast(transf.position, Vector3.down, out groundHit, heightDispl + 0.05f, layerGround);

        isJumping = jumpPress || !isGrounded;
        isWalking = mvt.magnitude > 0.1f;

        //Attack!!
        //Só ataca se não estiver pulando, e se o collider estiver desligado- também limita a quantidade de ataques
        if (attackPress && !isJumping && !swordCollider.enabled)
        {
            animator.SetTrigger("Attacked");
            swordCollider.enabled = true;
            Invoke("DisableSwordCollision", 0.3f);
        }

        //Jump!!

        rb.useGravity = isJumping;
        rb.constraints = (RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ);

        if (!isJumping)
            rb.constraints = rb.constraints | RigidbodyConstraints.FreezePositionY;

        if (jumpPress && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        if (isWalking)
            transf.LookAt(transf.position + transfCam.TransformDirection(mvt) * 8);
        if (isWalking)
            transf.Translate(0, 0, mvt.magnitude * speedMovement * Time.deltaTime);

        animator.SetFloat("Velocity", mvt.magnitude);
        animator.SetBool("Grounded", isGrounded);

        if (!isJumping)
        {
            RaycastHit hit;
            bool rcHitGround = Physics.Raycast(transf.position, Vector3.down, out hit, Mathf.Infinity, layerGround);

            if (rcHitGround)
            {
                Vector3 pos = transf.position;
                pos.y = hit.point.y + heightDispl;
                transf.position = pos;

                groundPoint = hit.point;
            }
               
            rb.velocity = Vector3.zero;
        }
    }
    void DisableSwordCollision()
    {
        swordCollider.enabled = false;
    }
}
