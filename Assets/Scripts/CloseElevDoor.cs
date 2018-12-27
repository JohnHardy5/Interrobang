using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseElevDoor : MonoBehaviour {
    public Animator anim;

    private bool hasBeenTriggered = false;
    private float waitTime = 3.0f;

    private void OnTriggerEnter(Collider other)
    {
        if (!hasBeenTriggered && other.gameObject.CompareTag("Player"))
        {
            anim.SetTrigger("OpenToCloseDoor");
            hasBeenTriggered = true;
            StartCoroutine(LoadGame());
        }
    }

    IEnumerator LoadGame()
    {
        yield return new WaitForSeconds(waitTime);
        GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().LoadEndScene();
    }
}
