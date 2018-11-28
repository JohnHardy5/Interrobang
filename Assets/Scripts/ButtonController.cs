using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour {

    public GameObject GameManager;
    public DoorController doorToOpen;
    public Transform buttonPressT;
    public int numTimesToIterate;
    public float moveDistance;
    public float animationTime;
    public float buttonHoldTime;

    private GameManager GMscript;
    private bool isUp = true;
    private bool isMoving = false;
    private int moveDir = -1;
    private float timer = 0.0f;

    private void Start()
    {
        GMscript = GameManager.GetComponent<GameManager>();
    }

    //Checks the timer to release the button automatically, if the button is down.
    private void Update()
    {
        if (!isUp && Time.time - timer > buttonHoldTime)
        {
            ReleaseButton();
        }
    }

    //Move button into next state
    IEnumerator MoveButton()
    {
        isMoving = true;
        for (int i = 0; i < numTimesToIterate; i++)
        {
            buttonPressT.Translate(0.0f, moveDistance * moveDir, 0.0f);
            yield return new WaitForSeconds(animationTime);
        }
        moveDir *= -1;
        isMoving = false;
    }

    //Start a timer to release the button. If the timer is not reset in time, release the button.
    void StartTimer ()
    {
        timer = Time.time;
    }

    //Moves button into "down" state
    public void PressButton ()
    {
        if (isUp && !isMoving)
        {
            StartCoroutine(MoveButton());
            GMscript.IncrementLevel();
            doorToOpen.OpenDoor();
            isUp = false;
        }
        StartTimer();
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
