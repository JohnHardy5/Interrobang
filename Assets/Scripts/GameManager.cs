/*
 * Written by: John Hardy
 * Controls the state of the game as the player progresses through
 * each level. Also controls game settings and other information
 * about the state of the current level
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    //Game settings
    public float pointOfNoReturn;//Point at which player has fallen out of map
    public GameObject playerGO;
    [HideInInspector] public Vector3 respawnLocation;//Don't want anyone messing with this
    public GameObject EscapeMenu;
    public int currentLevel = 1;
    public int currentIterration = 0;
    
    private FirstPersonController playerScript;
    private Text timeText;
    private Transform playerT;
    private float startTime;
    private float currentPlayTime;

    private void Awake()
    {
        startTime = Time.time;
    }

    // Use this for initialization
    void Start () {
        playerScript = playerGO.GetComponent<FirstPersonController>();
        playerT = playerGO.GetComponent<Transform>();
        respawnLocation = playerT.position;
        timeText = GameObject.FindGameObjectWithTag("Overlay").GetComponentInChildren<Text>();
        Debug.Log(timeText.text);
    }

    private void Update()
    {
        if (Input.GetKeyDown("escape")) ToggleMenu();
        if (playerT.position.y < pointOfNoReturn) playerScript.Kill();
        currentPlayTime = Time.time - startTime;
    }

    public void SetSpawnLocation(Vector3 pos)
    {
        respawnLocation = pos;
    }

    public void ToggleMenu()
    {
        playerScript.canMove = !playerScript.canMove;
        playerScript.ToggleCursor();
        bool status = EscapeMenu.activeSelf;
        EscapeMenu.SetActive(!status);
    }

    public void LoadStartScene()
    {
        SceneManager.LoadScene("StartScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
