using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour {

    public Transform door;
    public Transform hinge;
    public bool rotateClockwise;
    public bool isOpen;
    public int degOfRotation;

    private Vector3 hingePos;
    int rotationDir = 1;



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
        for (int i = 0; i < degOfRotation; i++)
        {
            door.RotateAround(hingePos, Vector3.up, rotationDir);
            yield return new WaitForSeconds(0.001f);
        }
        rotationDir *= -1;
    }

    //Rotates Door about hinge into "open" position
    public void OpenDoor()
    {
        if (isOpen) return;
        StartCoroutine(RotateDoor());
        isOpen = true;
    }

    //Rotates Door about hinge into "closed" position
    public void CloseDoor()
    {
        if (!isOpen) return;
        StartCoroutine(RotateDoor());
        isOpen = false;
    }
}
