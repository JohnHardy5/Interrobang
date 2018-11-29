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
    public float pointOfNoReturn;//Point at which player has fallen out of map
    public Vector3 defaultRespawnPoint;//If the spawn point for the current level couldn't be found, go here.
    public GameObject playerGO;
    [HideInInspector] public Vector3 respawnLocation;//Don't want anyone messing with this

    private FirstPersonController playerScript;
    private Transform playerT;

    // Use this for initialization
    void Start () {
        playerScript = playerGO.GetComponent<FirstPersonController>();
        playerT = playerGO.GetComponent<Transform>();
        respawnLocation = defaultRespawnPoint;
    }

    private void Update()
    {
        if (playerT.position.y < pointOfNoReturn) playerScript.Kill();
    }

    public void SetSpawnLocation(Vector3 pos)
    {
        respawnLocation = pos;
    }
}
