using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour {

    public DoorController doorToOpen;
    public Transform buttonPressT;
    public int numTimesToIterate;
    public float moveDistance;
    public float waitTime;
    public float checkTime;

    private bool isUp = true;
    private bool isMoving = false;
    private int moveDir = -1;

    //Move button into next state
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

    //Set a timer to release the button. If the coroutine is not stopped in time, release the button.
    IEnumerator CheckButton ()
    {
        yield return new WaitForSeconds(checkTime);
        //ReleaseButton();
        Debug.Log("Release Button");
    }

    //Moves button into "down" state
    public void PressButton ()
    {
        StopCoroutine(CheckButton());
        StartCoroutine(CheckButton());
        if (isUp && !isMoving)
        {
            StartCoroutine(MoveButton());
            doorToOpen.OpenDoor();
            isUp = false;
        }
    }

    //Moves button in "up" state
    public void ReleaseButton ()
    {
        if (!isUp && !isMoving)
        {
            StartCoroutine(MoveButton());
            isUp = true;
        }
    }
}
