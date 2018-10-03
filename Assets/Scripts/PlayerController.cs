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
    private float slopeModifier = 90.0f;

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
        ManipulatePlayerAndCameraOrientation();
        RaycastHit hit;
        //Position the ray slightly forward of the player in order to detect slopes in front of it
        Vector3 rayCastPosition = playerTransform.position + (playerTransform.forward * rayCastForwardOffset);
        bool didHit = Physics.Raycast(rayCastPosition, Vector3.down, out hit, rayCastDistance);
        bool isGrounded = didHit && hit.distance <= minGroundDistance;
        float moveX = Input.GetAxisRaw("Horizontal") * Time.deltaTime;
        float moveY = 0.0f;
        float moveZ = Input.GetAxisRaw("Vertical") * Time.deltaTime;
        bool isMoving = moveX != 0f || moveZ != 0f;
        if (isGrounded)
        {
            SetFriction(friction);
            SprintPlayer();
            JumpPlayer();
            if (isMoving) moveY = DetectSlope(hit);
        } else
        {
            maxSpeed = maxAirSpeed;
            movementSpeed = airSpeed;
            SetFriction(0.0f);
        }
        if (isMoving) MovePlayer(moveX, moveY, moveZ);
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

    void MovePlayer (float moveX, float moveY, float moveZ)
    {
        Vector3 movement = new Vector3(moveX, moveY, moveZ);
        playerRigidBody.AddRelativeForce(movement * movementSpeed, ForceMode.Impulse);
        float currentSpeed = playerRigidBody.velocity.magnitude;
        Vector3 currVelocity = playerRigidBody.velocity;
        Vector3 maxedVelocity = currVelocity.normalized * maxSpeed;
        if (currentSpeed > maxSpeed)
        {
            //Don't change velocity in the y direction
            playerRigidBody.velocity = new Vector3(maxedVelocity.x, currVelocity.y, maxedVelocity.z);
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

    float DetectSlope(RaycastHit hit)
    {
        //angle between player forward vector and normal of surface
        //If we are on a flat surface, the angle between forward and the normal of the surface below is 90 degrees
        float slopeAngle = Vector3.Angle(playerTransform.TransformDirection(Vector3.forward), hit.normal) - slopeModifier;
        float upwardMovement = 0.0f;
        if (slopeAngle > 0 && slopeAngle <= maxSlopeAngle)
        {
            //upwardMovement = (slopeAngle / 180f); /// movementSpeed / friction * playerRigidBody.mass;
            // Debug.Log("slopeAngle: " + slopeAngle);
            Debug.Log("upwardMovement: " + upwardMovement);
        }
        return upwardMovement;
    }

    public void SetFriction (float f)
    {
        playerCollider.material.dynamicFriction = f;
        playerCollider.material.staticFriction = f;
        if (f < 1.0f)
        {
            playerCollider.material.frictionCombine = PhysicMaterialCombine.Minimum;
        } else
        {
            playerCollider.material.frictionCombine = PhysicMaterialCombine.Maximum;
        }
    }
}
