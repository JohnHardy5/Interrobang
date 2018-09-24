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
    public GameObject MainCameraObj;
    private GameManager GameManagerScript;
    //private MainCameraController MainCameraScript;
    private Transform playerTransform;
    private float movementSpeed;
    private float sprintSpeed;

    // Use this for initialization
    void Start () {
        GameManagerObject = GameObject.Find("Game Manager");
        GameManagerScript = GameManagerObject.GetComponent<GameManager>();
        MainCameraObj = GameObject.Find("Main Camera");
        //MainCameraScript = MainCameraObj.GetComponent<MainCameraController>();
        playerTransform = GetComponent<Transform>();
    }
	
    // Update is called once per frame
    void Update () {
        movementSpeed = GameManagerScript.playerMovementSpeed;
        sprintSpeed = GameManagerScript.playerSprintSpeed;
        if (Input.GetKey("left shift")) movementSpeed = sprintSpeed;
        //set rotation so that the player is upright and facing the direction that the camera is pointing
        float cameraY = MainCameraObj.transform.eulerAngles.y;
        playerTransform.eulerAngles = new Vector3(0.0f, cameraY, 0.0f);
        float horizInput = Input.GetAxis("Horizontal");
        float vertInput = Input.GetAxis("Vertical");
        playerTransform.Translate(playerTransform.right * (horizInput * movementSpeed), Space.World);
        playerTransform.Translate(playerTransform.forward * (vertInput * movementSpeed), Space.World);
    }
}
