using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenElevDoor : MonoBehaviour {
    public Animator anim;

    private bool hasBeenTriggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!hasBeenTriggered && other.gameObject.CompareTag("Player"))
        {
            anim.Play("ElevatorDoorOpenAnim");
            hasBeenTriggered = true;
        }
    }
}
