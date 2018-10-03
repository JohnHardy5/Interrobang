/*
 * Written by: John Hardy
 * Controls the state of the game as the player progresses through
 * each level. Also controls game settings and other information
 * about the state of the current level
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldGameManager : MonoBehaviour
{

    //Game settings
    public float playerMovementSpeed;
    public float playerSprintSpeed;
    public float playerAirSpeed;
    public float playerMaxSpeed;
    public float playerMaxSprintSpeed;
    public float playerMaxAirSpeed;
    public float playerJumpStrength;
    public float playerMinGroundDistance;
    public float playerMaxSlopeAngle;
    public float playerFriction;
    public float mouseSensitivity;

    // Use this for initialization
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
}
