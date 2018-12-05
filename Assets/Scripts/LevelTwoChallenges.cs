using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTwoChallenges : MonoBehaviour {

    private LoopingScript LS;
    private int loopCounter;
    private GameObject Level2_1_1Spikes;
    private GameObject Level2_1_2Spikes;
    private GameObject Level2_1_3GameObjects;
    private GameObject Button_Group;

    private float timeSinceLastButtonChange = 0.0f;

    public GameObject LoopyBoi;
    public float buttonChangeWaitTime;

    // Use this for initialization
    void Start()
    {
        LS = LoopyBoi.GetComponent<LoopingScript>();
        Level2_1_1Spikes = GameObject.Find("Level 2.1.1 Spikes");
        Level2_1_2Spikes = GameObject.Find("Level 2.1.2 Spikes");
        Level2_1_3GameObjects = GameObject.Find("Level 2.1.3 Objects");
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

        switch (loopCounter)
        {
            case 0:
                Level2_1_1Spikes.SetActive(true);
                Level2_1_2Spikes.SetActive(false);
                Level2_1_3GameObjects.SetActive(false);
                break;
            case 1:
                Level2_1_1Spikes.SetActive(false);
                Level2_1_2Spikes.SetActive(true);
                Level2_1_3GameObjects.SetActive(false);
                break;
            case 2:
                Level2_1_1Spikes.SetActive(false);
                Level2_1_2Spikes.SetActive(false);
                Level2_1_3GameObjects.SetActive(true);
                break;
            default:
                Level2_1_1Spikes.SetActive(false);
                Level2_1_2Spikes.SetActive(false);
                Level2_1_3GameObjects.SetActive(false);
                break;
        }
    }
}
