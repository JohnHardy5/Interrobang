/*
 * Written by: John Hardy
 * Manipulates the player object and maincamera by gathering key
 * and mouse inputs and manipulating the camera. Note that the
 * movement keys only control the player object while the mouse
 * controls the camera and player rotation. However, the players movement will always
 * be relative to where the camera is pointing.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public GameObject GameManagerObject;
    public GameObject CameraObject;

    private GameManager GameManagerScript;
    private Transform playerTransform;
    private Transform cameraTransform;
    private Rigidbody playerRigidBody;
    private CapsuleCollider playerCollider;
    private float movementSpeed;
    private float sprintSpeed;
    private float airSpeed;
    private float maxSpeed;
    private float maxSprintSpeed;
    private float maxAirSpeed;
    private float jumpStrength;
    private float minGroundDistance;
    private float maxSlopeAngle;
    private float friction;
    private float mouseSensitivity;
    private float minY = -90f;
    private float maxY = 90f;
    private float yaw;
    private float pitch;
    private float rayCastDistance = 1000f;
    private float rayCastForwardOffset = 0.25f;
    private float slopeModifier = 30.0f;

    // Use this for initialization
    void Start () {
        GameManagerScript = GameManagerObject.GetComponent<GameManager>();
        playerTransform = GetComponent<Transform>();
        cameraTransform = CameraObject.GetComponent<Transform>();
        playerRigidBody = GetComponent<Rigidbody>();
        playerCollider = GetComponent<CapsuleCollider>();
        yaw = playerTransform.eulerAngles.y;
        pitch = playerTransform.eulerAngles.x;
    }
	
    // Update is called once per frame
    void Update () {
        LoadGlobals();
        RaycastHit hit;
        //Position the ray slightly forward of the player in order to detect slopes in front of it
        Vector3 rayCastPosition = playerTransform.position + (playerTransform.forward * rayCastForwardOffset);
        //Debug.Log("RayCastPosition: " + rayCastPosition);
        //Debug.DrawRay(rayCastPosition, Vector3.down, Color.red);
        bool didHit = Physics.Raycast(rayCastPosition, Vector3.down, out hit, rayCastDistance);
        bool isGrounded = didHit && hit.distance <= minGroundDistance;
        ManipulatePlayerAndCameraOrientation();
        if (isGrounded)
        {
            SprintPlayer();
            JumpPlayer();
        }
        MovePlayer(hit, didHit);
    }

    void LoadGlobals ()
    {
        movementSpeed = GameManagerScript.playerMovementSpeed;
        sprintSpeed = GameManagerScript.playerSprintSpeed;
        airSpeed = GameManagerScript.playerAirSpeed;
        maxSpeed = GameManagerScript.playerMaxSpeed;
        maxSprintSpeed = GameManagerScript.playerMaxSprintSpeed;
        maxAirSpeed = GameManagerScript.playerMaxAirSpeed;
        jumpStrength = GameManagerScript.playerJumpStrength;
        minGroundDistance = GameManagerScript.playerMinGroundDistance;
        maxSlopeAngle = GameManagerScript.playerMaxSlopeAngle;
        friction = GameManagerScript.playerFriction;
        mouseSensitivity = GameManagerScript.mouseSensitivity;
    }

    void ManipulatePlayerAndCameraOrientation ()
    {
        yaw += mouseSensitivity * Input.GetAxis("Mouse X");
        pitch -= mouseSensitivity * Input.GetAxis("Mouse Y");
        pitch = Mathf.Clamp(pitch, minY, maxY);
        playerTransform.eulerAngles = new Vector3(0f, yaw, 0f);//Don't pitch the player
        cameraTransform.eulerAngles = new Vector3(pitch, yaw, 0f);
    }

    void MovePlayer (RaycastHit hit, bool didHit)
    {
        float currentSpeed = playerRigidBody.velocity.magnitude;
        float horizInput = Input.GetAxisRaw("Horizontal") * Time.deltaTime;
        float vertInput = Input.GetAxisRaw("Vertical") * Time.deltaTime;
        playerCollider.material.dynamicFriction = friction;
        playerCollider.material.staticFriction = friction;
        playerCollider.material.frictionCombine = PhysicMaterialCombine.Maximum;
        if (horizInput != 0.0f || vertInput != 0.0f)
        {
            float slopeAngle = 0.0f;
            float upwardMovement = 0.0f;
            if (didHit)
            {
                //angle between player forward vector and normal of surface
                slopeAngle = Vector3.Angle(playerTransform.TransformDirection(Vector3.forward), hit.normal);
                if (hit.distance <= minGroundDistance)//Grounded
                {
                    if (slopeAngle > 90.0f && slopeAngle <= (maxSlopeAngle + 90.0f))
                    {
                        //If we are on a flat surface, the angle between forward and the normal of the surface below is 90 degrees
                        upwardMovement = slopeAngle - slopeModifier / maxSlopeAngle;
                        Debug.Log("upwardMovement: " + upwardMovement);
                    }
                } else//Not grounded
                {
                    maxSpeed = maxAirSpeed;
                    movementSpeed = airSpeed;
                    playerCollider.material.dynamicFriction = 0.0f;
                    playerCollider.material.staticFriction = 0.0f;
                    playerCollider.material.frictionCombine = PhysicMaterialCombine.Minimum;
                }
            }
            Vector3 movement = new Vector3(horizInput, upwardMovement, vertInput);
            playerRigidBody.AddRelativeForce(movement * movementSpeed, ForceMode.Impulse);
            if (currentSpeed > maxSpeed) playerRigidBody.velocity = playerRigidBody.velocity.normalized * maxSpeed;
        }
    }

    void SprintPlayer ()
    {
        if (Input.GetKey("left shift"))
        {
            movementSpeed = sprintSpeed;
            maxSpeed = maxSprintSpeed;
        }
    }

    void JumpPlayer ()
    {
        if (Input.GetKeyDown("space"))
        {
            playerRigidBody.AddForce(Vector3.up * jumpStrength, ForceMode.Impulse);
        }
    }
}
