/*
 * Written by: John Hardy
 * Uses inputs from player controller script to control the position and orientation
 * of the camera. Also has public methods for camera rotation, movement, and positioning.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraController : MonoBehaviour {

    public GameObject GMobj;
    private Transform CameraTransform;
    private GameManager GMscript;
    private float mouseSensitivity = 5f;//default value
    private float yaw = 0f;
    private float pitch = 0f;

	// Use this for initialization
	void Start ()
    {
        GMobj = GameObject.Find("Game Manager");
        GMscript = GMobj.GetComponent<GameManager>();
        CameraTransform = this.transform;
	}
	
	// Update is called once per frame
	void Update ()
    {
        mouseSensitivity = GMscript.mouseSensitivity;
        yaw += mouseSensitivity * Input.GetAxis("Mouse X");
        pitch -= mouseSensitivity * Input.GetAxis("Mouse Y");
        CameraTransform.eulerAngles = new Vector3(pitch, yaw, 0f);
    }

    public bool RotateHorizontal(float turnRate)
    {
        CameraTransform.Rotate(Vector3.up * turnRate);
        return true;
    }

    public bool RotateVertical(float turnRate)
    {
        CameraTransform.Rotate(Vector3.right * turnRate);
        return true;
    }
}
