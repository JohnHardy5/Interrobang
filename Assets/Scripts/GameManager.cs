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
    private string playTime = "0:0:000";
    private bool shouldRecordTime = false;

    private void Awake()
    {
        if (SceneManager.GetActiveScene().name.Equals("MainScene"))
        {
            shouldRecordTime = true;
            startTime = Time.time;
        }
    }

    // Use this for initialization
    void Start () {
        playerScript = playerGO.GetComponent<FirstPersonController>();
        playerT = playerGO.GetComponent<Transform>();
        respawnLocation = playerT.position;
        if (shouldRecordTime) timeText = GameObject.FindGameObjectWithTag("Overlay").GetComponentInChildren<Text>();
    }

    private void Update()
    {
        if (Input.GetKeyDown("escape")) ToggleMenu();
        if (playerT.position.y < pointOfNoReturn) playerScript.Kill();
        if (shouldRecordTime) UpdatePlayTime();
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

    public void LoadEndScene()
    {
        PlayerData.PlayTime = playTime;
        SceneManager.LoadScene("EndScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    private void UpdatePlayTime ()
    {
        float currentPlayTime = Time.time - startTime;
        int mins = (int)currentPlayTime / 60;
        currentPlayTime %= 60;//Remove the minutes
        int secs = (int)currentPlayTime;//Seconds are the whole number portion
        currentPlayTime = currentPlayTime - (int)currentPlayTime;//Only keeps the decimal portion
        currentPlayTime *= 1000;//Convert to milliseconds
        int millis = (int)currentPlayTime;//We don't care about time smaller than milliseconds
        playTime = mins + ":" + secs + ":" + millis;
        timeText.text = playTime;
    }
}
