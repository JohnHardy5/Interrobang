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

    public GameObject GameManager;
    public GameObject MainCamera;
    private Transform playerTransform;

    public float movementSpeed;
    private float horizInput;
    private float vertInput;

	// Use this for initialization
	void Start () {
        GameManager = GameObject.Find("Game Manager");
        MainCamera = GameObject.Find("Main Camera");
        playerTransform = this.transform;
	}
	
	// Update is called once per frame
	void Update () {
        //set rotation so that player is upright facing camera direction
        playerTransform.eulerAngles = new Vector3(0.0f, MainCamera.transform.eulerAngles.y, 0.0f);
        horizInput = Input.GetAxis("Horizontal");
        vertInput = Input.GetAxis("Vertical");
        playerTransform.Translate(playerTransform.right * (horizInput * movementSpeed), Space.World);
        playerTransform.Translate(playerTransform.forward * (vertInput * movementSpeed), Space.World);
    }
}
