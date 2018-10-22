using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour {

    public Transform hinge;
    public Transform door;
    public bool rotateClockwise;
    public float degOfRotation;

    private Vector3 hingePos;
    private bool isOpen = false;

	// Use this for initialization
	void Start () {
        hingePos = hinge.position;
	}

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            if (isOpen)
            {
                CloseDoor();
            } else
            {
                OpenDoor();
            }
        }
    }

    //Rotates Door about hinge into "open" position
    public void OpenDoor()
    {
        if (isOpen) return;
        int rotationDir = rotateClockwise ? 1 : -1;
        for (int i = 0; i < degOfRotation; i++)
        {
            door.RotateAround(hingePos, 1.0f * rotationDir);
        }
        isOpen = true;
    }

    //Rotates Door about hinge into "closed" position
    public void CloseDoor()
    {
        if (!isOpen) return;
        int rotationDir = rotateClockwise ? 1 : -1;
        for (int i = 0; i < degOfRotation; i++)
        {
            door.RotateAround(hingePos, -1.0f * rotationDir);
        }
        isOpen = true;
    }
}
