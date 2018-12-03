using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTwoChallenges : MonoBehaviour {
    public GameObject LoopyBoi;

    private LoopingScript LS;
    private int loopCounter;
    private GameObject Level2_1_1Spikes;
    private GameObject Level2_1_2Spikes;


    // Use this for initialization
    void Start()
    {
        LS = LoopyBoi.GetComponent<LoopingScript>();
        Level2_1_1Spikes = GameObject.Find("Level 2.1.1 Spikes");
        Level2_1_2Spikes = GameObject.Find("Level 2.1.2 Spikes");
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
                break;
            case 1:
                Level2_1_1Spikes.SetActive(false);
                Level2_1_2Spikes.SetActive(true);
                break;
            case 2:
                Level2_1_1Spikes.SetActive(false);
                Level2_1_2Spikes.SetActive(false);
                break;
            default:
                Level2_1_1Spikes.SetActive(false);
                Level2_1_2Spikes.SetActive(false);
                break;
        }
    }
}
