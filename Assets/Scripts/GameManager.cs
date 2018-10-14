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
    public double loopingSectionX = 15.0;
    public double loopingSectionZ = 204.5;

    public GameObject playerGO;
    private FirstPersonController playerScript;
    private Rigidbody playerRB;
    private Transform playerT;
    public GameObject Level;
    private float timeToWait;
    private float timeOfLastRotation;

    // Use this for initialization
    void Start () {
        playerScript = playerGO.GetComponent<FirstPersonController>();
        playerRB = playerGO.GetComponent<Rigidbody>();
        playerT = playerGO.GetComponent<Transform>();
        timeToWait = 2f;
        timeOfLastRotation = Time.time;
    }

    int timeOfRotation = 0;
    bool enoughTimePassed = false;
    int angleOfRotation = 90;
    int amountRotated = 0;

    private void Update()
    {

        //if (Time.time - timeOfLastRotation > timeToWait)
        //{
        //    amountRotated++;
        //    timeOfRotation = 45;
        //    int i;
        //    for (i = 0; i < timeOfRotation; i++)
        //    {
        //        Level.transform.Rotate(0, 0, Time.deltaTime * 2);
        //    }
        //    Level.transform.Rotate(0, 0, 1);
        //    if (amountRotated == angleOfRotation)
        //    {
        //        timeOfLastRotation = Time.time;
        //        amountRotated = 0;
        //    }

        //}

        if (playerT.position.y < pointOfNoReturn) StartCoroutine(KillPlayer());
        if (playerT.position.x >= loopingSectionX && playerT.position.z >= loopingSectionZ) StartCoroutine(KillPlayer());

    }

    IEnumerator KillPlayer ()
    {
        playerT.position = this.transform.position;
        yield return new WaitForSeconds(0.125f); // Prevents audio distortion
        playerScript.PlayDeathSound();
    }

    IEnumerator teleportPlayer()
    {
        playerT.position = new Vector3(0.0f, 1.5f, 0.0f);
        yield return new WaitForSeconds(0.125f);//Prevents audio distortion
        playerScript.PlayDeathSound();
    }
}
