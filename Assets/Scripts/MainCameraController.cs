/*
 * Written by: John Hardy
 * Uses inputs from player controller script to control the position and orientation
 * of the camera. Also has public methods for camera rotation, movement, and positioning.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraController : MonoBehaviour {

    public GameObject GameManagerObject;
    private Transform CameraTransform;
    private GameManager GameManagerScript;
    private float mouseSensitivity;
    private float minY = -90f;
    private float maxY = 90f;
    private float yaw;
    private float pitch;

	// Use this for initialization
	void Start ()
    {
        GameManagerObject = GameObject.Find("Game Manager");
        GameManagerScript = GameManagerObject.GetComponent<GameManager>();
        CameraTransform = GetComponent<Transform>();
        yaw = CameraTransform.eulerAngles.y;
        pitch = CameraTransform.eulerAngles.x;
	}
	
	// Update is called once per frame
	void Update ()
    {
        mouseSensitivity = GameManagerScript.mouseSensitivity;
        yaw += mouseSensitivity * Input.GetAxis("Mouse X");
        pitch -= mouseSensitivity * Input.GetAxis("Mouse Y");
        pitch = Mathf.Clamp(pitch, minY, maxY);
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
