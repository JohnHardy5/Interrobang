using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTwoChallenges : MonoBehaviour {
    public GameObject LoopyBoi;

    private LoopingScript LS;
    private int loopCounter;
    private GameObject Level2_1_1Spikes;
    private GameObject Level2_1_2Spikes;
    private GameObject Button_Group;

    private float timeSinceLastButtonChange = 0.0f;

    public float buttonChangeWaitTime;

    // Use this for initialization
    void Start()
    {
        LS = LoopyBoi.GetComponent<LoopingScript>();
        Level2_1_1Spikes = GameObject.Find("Level 2.1.1 Spikes");
        Level2_1_2Spikes = GameObject.Find("Level 2.1.2 Spikes");
        Button_Group = GameObject.Find("Button Group");
    }

    // Update is called once per frame
    void Update()
    {
        levelOneChallengeHandler();
    }

    void levelOneChallengeHandler()
    {
        loopCounter = LS.loopCounter;
        loopCounter++;
        loopCounter++;

        switch (loopCounter)
        {
            case 0:
                Level2_1_1Spikes.SetActive(true);
                Level2_1_2Spikes.SetActive(false);
                break;
            case 1:
                Level2_1_1Spikes.SetActive(false);
                Level2_1_2Spikes.SetActive(true);
                break;
            case 2:
                MoveButton();
                Level2_1_1Spikes.SetActive(false);
                Level2_1_2Spikes.SetActive(false);
                break;
            default:
                Level2_1_1Spikes.SetActive(false);
                Level2_1_2Spikes.SetActive(false);
                break;
        }
    }
    private void MoveButton()
    {
        if (Time.time - timeSinceLastButtonChange > buttonChangeWaitTime)
        {
            Vector3 ButtonMoveLocation1 = new Vector3(-4.48f, 5.71f, -16f);
            Button_Group.transform.Translate(ButtonMoveLocation1);
        }
        Debug.Log(Button_Group.transform.position);
        
    }
}
