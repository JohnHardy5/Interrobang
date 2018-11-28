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
    public int currentLevel;
    public Vector3 defaultRespawnPoint;//If the spawn point for the current level couldn't be found, go here.
    public GameObject Level_1;
    public GameObject Level_2;
    public GameObject Level_3;
    [HideInInspector] public Vector3 respawnLocation;//Don't want anyone messing with this

    public GameObject playerGO;
    private FirstPersonController playerScript;
    private Rigidbody playerRB;
    private Transform playerT;
    private double loopingSectionX = 7.0;
    private double loopingSectionZ = 202;
    private double zPositionOffset = 204.5;

    // Use this for initialization
    void Start () {
        playerScript = playerGO.GetComponent<FirstPersonController>();
        playerRB = playerGO.GetComponent<Rigidbody>();
        playerT = playerGO.GetComponent<Transform>();
        respawnLocation = FindSpawnLocation(currentLevel);
    }

    private void Update()
    {
        if (playerT.position.y < pointOfNoReturn) playerScript.Kill();
        if (playerT.position.x >= loopingSectionX && playerT.position.z >= loopingSectionZ)
        {
            playerScript.Teleport(respawnLocation);
        }
    }

    private Vector3 FindSpawnLocation(int currLevel)
    {
        GameObject[] spawnPoints = GameObject.FindGameObjectsWithTag("Respawn");
        foreach (GameObject spawnPoint in spawnPoints)
        {//Ensure that the parent of the spawn point is the same GameObject as the current level
            GameObject spawnParent = spawnPoint.transform.parent.gameObject;
            switch (currLevel)
            {
                case 1:
                    if (spawnParent == Level_1)
                    {
                        return spawnPoint.transform.position;
                    }
                    break;
                case 2:
                    if (spawnParent == Level_2)
                    {
                        return spawnPoint.transform.position;
                    }
                    break;
                case 3:
                    if (spawnParent == Level_3)
                    {
                        return spawnPoint.transform.position;
                    }
                    break;
            }
        }
        Debug.LogError("Spawn point not found, using default location!");
        return defaultRespawnPoint;
    }

    public void IncrementLevel()
    {
        currentLevel++;
        respawnLocation = FindSpawnLocation(currentLevel);
    }
}
