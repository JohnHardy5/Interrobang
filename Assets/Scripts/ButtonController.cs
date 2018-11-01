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
    private bool isPressed = false;
    private int moveDir = -1;

    //Figure out if we were pressed in the last frame and then release when we are no longer pressed
    private void Update()
    {
        //if (!isUp) StartCoroutine(CheckButton());
        //isPressed = false;
    }

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

    //Check if button is depressed, wait an instant, and then check again. If the button is no longer pressed, release the button.
    IEnumerator CheckButton()
    {
        if (isPressed)
        {
            yield return new WaitForSeconds(checkTime);
            if (!isPressed)
            {
                ReleaseButton();
            }
        }
    }

    //Moves button into "down" state
    public void PressButton ()
    {
        isPressed = true;
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
