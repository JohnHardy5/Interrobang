using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour {

    public DoorController doorToOpen;
    public Transform buttonPressT;
    public int numTimesToIterate;
    public float moveDistance;
    public float waitTime;

    private bool isUp = true;
    private bool isMoving = false;
    private int moveDir = -1;
    
    IEnumerator MoveButton()
    {
        isMoving = true;
        for (int i = 0; i < numTimesToIterate; i++)
        {
            buttonPressT.Translate(0.0f, moveDistance * moveDir, 0.0f);
            yield return new WaitForSeconds(waitTime);
        }
        moveDir *= -1;
        isMoving = false;
    }

    //Moves button into "down" state
    public void PressButton ()
    {
        if (!isUp || isMoving) return;
        StartCoroutine(MoveButton());
        doorToOpen.OpenDoor();
        isUp = false;
    }

    //Moves button in "up" state
    public void ReleaseButton ()
    {
        if (isUp || isMoving) return;
        StartCoroutine(MoveButton());
        isUp = true;
    }
}
