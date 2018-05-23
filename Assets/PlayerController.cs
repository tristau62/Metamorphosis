using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator), typeof(Rigidbody), typeof(CapsuleCollider))]
[RequireComponent(typeof(CharacterInputController))]
public class PlayerController : MonoBehaviour {

    private Animator anim;
    private Rigidbody rb;
    private CharacterInputController cinput;

    public bool closeToJumpableGround;
    public float jumpableGroundNormalMaxAngle = 45f;

    public bool isGrounded;

    public float animationSpeed = 1.5f;
    public float rootMovementSpeed = 1.5f;
    public float rootTurnSpeed = 1.5f;

    void Awake()
    {

        anim = GetComponent<Animator>();

        if (anim == null)
            Debug.Log("Animator could not be found");

        rb = GetComponent<Rigidbody>();

        if (rb == null)
            Debug.Log("Rigid body could not be found");

        cinput = GetComponent<CharacterInputController>();

        if (cinput == null)
            Debug.Log("CharacterInput could not be found");
    }

    // Use this for initialization
    void Start () {

        isGrounded = false;
        rb.sleepThreshold = 0f;

    }

    // Update is called once per frame
    void FixedUpdate () {
        float inputForward = 0f;
        float inputTurn = 0f;

        if (cinput.enabled)
        {
            inputForward = cinput.Forward;
            inputTurn = cinput.Turn;
        }

        bool walking = inputForward != 0f || inputTurn != 0f;
        anim.SetBool("isWalking", walking);

        

        //onCollisionStay() doesn't always work for checking if the character is grounded from a playability perspective
        //Uneven terrain can cause the player to become technically airborne, but so close the player thinks they're touching ground.
        //Therefore, an additional raycast approach is used to check for close ground
        if(CheckGroundNear(this.transform.position, jumpableGroundNormalMaxAngle, 0.1f, 1f, out closeToJumpableGround))
            isGrounded = true;


        //anim.SetFloat("velx", inputTurn);
        //anim.SetFloat("vely", inputForward);
        anim.SetBool("isFalling", !isGrounded);


        //clear for next OnCollisionStay() callback
        isGrounded = false;
    }

    //This is a physics callback
    void OnCollisionStay(Collision collision)
    {
        isGrounded = true;
        Debug.Log("IsGrounded");

    }

    //This is a physics callback
    void OnCollisionEnter(Collision collision)
    {

        if (collision.transform.gameObject.tag == "ground")
        {

            EventManager.TriggerEvent<PlayerLandsEvent, Vector3, float>(collision.contacts[0].point, collision.impulse.magnitude);

        }

    }

    void Animating(float h, float v)
    {
        // Create a boolean that is true if either of the input axes is non-zero.
        bool walking = h != 0f || v != 0f;

        // Tell the animator whether or not the player is walking.
        anim.SetBool("IsWalking", walking);
    }

    public static bool CheckGroundNear(
        Vector3 charPos,
        float jumpableGroundNormalMaxAngle,
        float rayDepth, //how far down from charPos will we look for ground?
        float rayOriginOffset, //charPos near bottom of collider, so need a fudge factor up away from there
        out bool isJumpable
    )
    {

        bool ret = false;
        bool _isJumpable = false;


        float totalRayLen = rayOriginOffset + rayDepth;

        Ray ray = new Ray(charPos + Vector3.up * rayOriginOffset, Vector3.down);

        int layerMask = 1 << LayerMask.NameToLayer("Default");


        RaycastHit[] hits = Physics.RaycastAll(ray, totalRayLen, layerMask);

        RaycastHit groundHit = new RaycastHit();

        foreach (RaycastHit hit in hits)
        {

            if (hit.collider.gameObject.CompareTag("ground"))
            {

                ret = true;

                groundHit = hit;

                _isJumpable = Vector3.Angle(Vector3.up, hit.normal) < jumpableGroundNormalMaxAngle;

                break; //only need to find the ground once

            }

        }

        DrawRay(ray, totalRayLen, hits.Length > 0, groundHit, Color.magenta, Color.green);

        isJumpable = _isJumpable;

        return ret;
    }

        public static void DrawRay(Ray ray, float rayLength, bool hitFound, RaycastHit hit, Color rayColor, Color hitColor)
        {

            Debug.DrawLine(ray.origin, ray.origin + ray.direction * rayLength, rayColor);

            if (hitFound)
            {
                //draw an X that denotes where ray hit
                const float ZBufFix = 0.01f;
                const float edgeSize = 0.2f;
                Color col = hitColor;

                Debug.DrawRay(hit.point + Vector3.up * ZBufFix, Vector3.forward * edgeSize, col);
                Debug.DrawRay(hit.point + Vector3.up * ZBufFix, Vector3.left * edgeSize, col);
                Debug.DrawRay(hit.point + Vector3.up * ZBufFix, Vector3.right * edgeSize, col);
                Debug.DrawRay(hit.point + Vector3.up * ZBufFix, Vector3.back * edgeSize, col);
            }
        }

}
