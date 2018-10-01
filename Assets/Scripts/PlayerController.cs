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
    private float movementSpeed;
    private float sprintSpeed;
    private float jumpStrength;
    private float minGroundDistanceToJump;
    private float maxSlopeAngle;
    private float mouseSensitivity;
    private float minY = -90f;
    private float maxY = 90f;
    private float yaw;
    private float pitch;
    private float rayCastDistance = 1000f;
    private float rayCastForwardOffset = 0.25f;

    // Use this for initialization
    void Start () {
        GameManagerScript = GameManagerObject.GetComponent<GameManager>();
        playerTransform = GetComponent<Transform>();
        cameraTransform = CameraObject.GetComponent<Transform>();
        playerRigidBody = GetComponent<Rigidbody>();
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
        Debug.DrawRay(rayCastPosition, Vector3.down, Color.red);
        bool didHit = Physics.Raycast(rayCastPosition, Vector3.down, out hit, rayCastDistance);
        ManipulatePlayerAndCameraOrientation();
        MovePlayer(hit, didHit);
        JumpPlayer(hit, didHit);
    }

    void LoadGlobals ()
    {
        movementSpeed = GameManagerScript.playerMovementSpeed;
        sprintSpeed = GameManagerScript.playerSprintSpeed;
        jumpStrength = GameManagerScript.playerJumpStrength;
        minGroundDistanceToJump = GameManagerScript.playerMinGroundDistanceToJump;
        maxSlopeAngle = GameManagerScript.playerMaxSlopeAngle;
        mouseSensitivity = GameManagerScript.mouseSensitivity;
    }

    void ManipulatePlayerAndCameraOrientation ()
    {
        yaw += mouseSensitivity * Input.GetAxis("Mouse X") * Time.deltaTime;
        pitch -= mouseSensitivity * Input.GetAxis("Mouse Y") * Time.deltaTime;
        pitch = Mathf.Clamp(pitch, minY, maxY);
        playerTransform.eulerAngles = new Vector3(0f, yaw, 0f);//Don't pitch the player
        cameraTransform.eulerAngles = new Vector3(pitch, yaw, 0f);
    }

    void MovePlayer (RaycastHit hit, bool didHit)
    {
        if (Input.GetKey("left shift")) movementSpeed = sprintSpeed;
        float horizInput = Input.GetAxis("Horizontal");
        float vertInput = Input.GetAxis("Vertical");
        float slopeAngle = Vector3.Angle(playerTransform.TransformDirection(Vector3.forward), hit.normal);
        float upwardMovement = 0.0f;
        //If we are on a flat surface, the angle between forward and the normal of the surface below is 90 degrees
        if (didHit && hit.distance < minGroundDistanceToJump && slopeAngle > 90.0f && slopeAngle <= (maxSlopeAngle + 90.0f)) upwardMovement = slopeAngle / (maxSlopeAngle + 90.0f);
        Vector3 movement = new Vector3(horizInput, upwardMovement, vertInput);
        //Only add force when movement keys are pressed
        if(horizInput != 0.0f || vertInput != 0.0f) playerRigidBody.AddRelativeForce(movement * movementSpeed, ForceMode.Impulse);
    }

    void JumpPlayer (RaycastHit hit, bool didHit)
    {
        if (didHit && Input.GetKeyDown("space") && hit.distance <= minGroundDistanceToJump)
        {
            playerRigidBody.AddForce(Vector3.up * jumpStrength, ForceMode.Impulse);
        }
    }
}
