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
                StartCoroutine(RotateDoor());
            }
            else
            {
                StartCoroutine(RotateDoor());
            }
        }
    }

    IEnumerator RotateDoor()
    {
        for (int i = 0; i < degOfRotation; i++)
        {
            print(Time.time);
            yield return new WaitForSeconds(0.125f);
        }
    }

    ////Rotates Door about hinge into "open" position
    //public void OpenDoor()
    //{
    //    if (isOpen) return;
    //    Debug.Log("Open door");
    //    StartCoroutine("ThisIsStupid");
    //    isOpen = true;
    //}

    ////Rotates Door about hinge into "closed" position
    //public void CloseDoor()
    //{
    //    if (!isOpen) return;
    //    Debug.Log("Close door");
    //    StartCoroutine("ThisIsStupid");
    //    isOpen = false;
    //}

    //IEnumerable ThisIsStupid ()
    //{
    //    Debug.Log("This is stupid");
    //    yield return new WaitForSeconds(0.125f);
    //    Debug.Log("This is stupid");
    //}

    ////IEnumerable RotateDoor()
    ////{
    ////    Debug.Log("rotating door");
    ////    for (int i = 0; i < degOfRotation; i++)
    ////    {
    ////        door.RotateAround(hingePos, Vector3.up, 1.0f * rotationDir);
    ////        yield return new WaitForSeconds(0.125f); // Prevents audio distortion
    ////    }
    ////    Debug.Log("done rotating door");
    ////}
}
