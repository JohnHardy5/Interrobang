/*
 * Written by: John Hardy
 * Controls the state of the game as the player progresses through
 * each level. Also controls game settings and other information
 * about the state of the current level
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    //Game settings
    public float mouseSensitivity;//TODO: Make adjustable mouse sensitivity
    public float pointOfNoReturn;//Point at which player has fallen out of map

    public GameObject playerGO;
    private UnityStandardAssets.Characters.FirstPerson.FirstPersonController playerScript;
    private Rigidbody playerRB;
    private Transform playerT;

    // Use this for initialization
    void Start () {
        playerScript = playerGO.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>();
        playerRB = playerGO.GetComponent<Rigidbody>();
        playerT = playerGO.GetComponent<Transform>();
    }

    private void Update()
    {
        if (playerT.position.y < pointOfNoReturn) StartCoroutine(KillPlayer());
    }

    IEnumerator KillPlayer ()
    {
        playerT.position = this.transform.position;
        yield return new WaitForSeconds(0.125f);//Prevents audio distortion
        playerScript.PlayDeathSound();
    }
}
