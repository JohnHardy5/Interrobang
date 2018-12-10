using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour {

    public Transform door;
    public Transform hinge;
    public bool rotateClockwise;
    public bool isOpen;
    public int numTimesToIterate;
    public float rotationDistance;
    public float waitTime;
    public int numConnectedButtons;

    private Vector3 hingePos;
    private int rotationDir = 1;
    private bool isMoving = false;

    // Use this for initialization
    void Start()
    {
        hingePos = hinge.position;
        rotationDir = rotateClockwise ? 1 : -1;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            if (isOpen)
            {
                CloseDoor();
            }
            else
            {
                OpenDoor();
            }
        }
    }

    //Rotates door into appropriate position
    IEnumerator RotateDoor()
    {
        isMoving = true;
        for (int i = 0; i < numTimesToIterate; i++)
        {
            door.RotateAround(hingePos, Vector3.up, rotationDistance * rotationDir);
            yield return new WaitForSeconds(waitTime);
        }
        rotationDir *= -1;
        isMoving = false;
    }

    //Rotates Door about hinge into "open" position
    public void OpenDoor()
    {
        if (isOpen || isMoving) return;
        StartCoroutine(RotateDoor());
        isOpen = true;
    }

    //Rotates Door about hinge into "closed" position
    public void CloseDoor()
    {
        if (!isOpen || isMoving) return;
        StartCoroutine(RotateDoor());
        isOpen = false;
    }

    public void DecrementNumConnectedButtons ()
    {
        numConnectedButtons--;
        if (numConnectedButtons <= 0)
        {
            OpenDoor();
        } 
    }
}
