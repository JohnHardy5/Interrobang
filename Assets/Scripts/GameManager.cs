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
    private double loopingSectionX = 7.0;
    private double loopingSectionZ = 202;
    private double zPositionOffset = 204.5;

    public GameObject playerGO;
    private FirstPersonController playerScript;
    private Rigidbody playerRB;
    private Transform playerT;
    public GameObject Level;

    // Use this for initialization
    void Start () {
        playerScript = playerGO.GetComponent<FirstPersonController>();
        playerRB = playerGO.GetComponent<Rigidbody>();
        playerT = playerGO.GetComponent<Transform>();
    }

    private void Update()
    {
        // if (playerT.position.y < pointOfNoReturn) playerScript.Kill();
        if (playerT.position.x >= loopingSectionX && playerT.position.z >= loopingSectionZ)
        {

            playerScript.Teleport(new Vector3(0.0f, .97f, 1.5f));
        }
    }
}
