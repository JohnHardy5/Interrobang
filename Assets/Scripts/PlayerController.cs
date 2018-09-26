/*
 * Written by: John Hardy
 * Manipulates the player object and maincamera by gathering key
 * and mouse inputs and calling camera methods. Note that the
 * movement keys only control the player object and the mouse only
 * controls the camera. However, the players movement will always
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
    private float mouseSensitivity;
    private float minY = -90f;
    private float maxY = 90f;
    private float yaw;
    private float pitch;

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
    void FixedUpdate () {
        loadGlobals();
        yaw += mouseSensitivity * Input.GetAxis("Mouse X") * Time.deltaTime;
        pitch -= mouseSensitivity * Input.GetAxis("Mouse Y") * Time.deltaTime;
        pitch = Mathf.Clamp(pitch, minY, maxY);
        playerTransform.eulerAngles = new Vector3(0f, yaw, 0f);//Don't pitch the player
        cameraTransform.eulerAngles = new Vector3(pitch, yaw, 0f);
        if (Input.GetKey("left shift")) movementSpeed = sprintSpeed;
        float horizInput = Input.GetAxis("Horizontal");
        float vertInput = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horizInput, 0.0f, vertInput);
        playerRigidBody.AddRelativeForce(movement * movementSpeed, ForceMode.Impulse);
        if (Input.GetKeyDown("space"))
        {
            playerRigidBody.AddForce(Vector3.up * jumpStrength, ForceMode.Impulse);
        }
    }

    void loadGlobals()
    {
        movementSpeed = GameManagerScript.playerMovementSpeed;
        sprintSpeed = GameManagerScript.playerSprintSpeed;
        jumpStrength = GameManagerScript.playerJumpStrength;
        mouseSensitivity = GameManagerScript.mouseSensitivity;
    }
}
