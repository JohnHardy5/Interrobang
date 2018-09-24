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

    public GameObject GMobj;
    public GameObject MainCameraObj;
    private GameManager GMscript;
    //private MainCameraController MainCameraScript;
    private Transform playerTransform;
    public float movementSpeed = 0.125f;//default value
    public float sprintSpeed = 0.5f;//default value
    private float horizInput;
    private float vertInput;

    // Use this for initialization
    void Start () {
        GMobj = GameObject.Find("Game Manager");
        GMscript = GMobj.GetComponent<GameManager>();
        MainCameraObj = GameObject.Find("Main Camera");
        //MainCameraScript = MainCameraObj.GetComponent<MainCameraController>();
        playerTransform = this.transform;
    }
	
    // Update is called once per frame
    void Update () {
        movementSpeed = GMscript.playerMovementSpeed;
        sprintSpeed = GMscript.playerSprintSpeed;
        if (Input.GetKey("left shift")) movementSpeed = sprintSpeed;
        //set rotation so that the player is upright and facing the direction that the camera is pointing
        playerTransform.eulerAngles = new Vector3(0.0f, MainCameraObj.transform.eulerAngles.y, 0.0f);
        horizInput = Input.GetAxis("Horizontal");
        vertInput = Input.GetAxis("Vertical");
        playerTransform.Translate(playerTransform.right * (horizInput * movementSpeed), Space.World);
        playerTransform.Translate(playerTransform.forward * (vertInput * movementSpeed), Space.World);
    }
}
