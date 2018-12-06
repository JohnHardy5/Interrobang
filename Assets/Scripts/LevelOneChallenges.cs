using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelOneChallenges : MonoBehaviour {
    public GameObject LoopyBoi;

    private LoopingScript LS;
    private int loopCounter;
    private GameObject Level1_1_1Spikes;
    private GameObject Level1_1_2Spikes;
    private GameObject Button_Group_1;
    private GameObject Button_Group_2;
    private GameObject Button_Group_3;
    private GameObject Button_Group_4;
    private GameObject Button_Group_5;
    private GameObject All_Button_Groups;

    private float timeSinceLastButtonChange = 0.0f;

    public float buttonChangeWaitTime;


    // Use this for initialization
    void Start () {
        LS = LoopyBoi.GetComponent<LoopingScript>();
        Level1_1_1Spikes = GameObject.Find("Level 1.1.1 Spikes");
        Level1_1_2Spikes = GameObject.Find("level 1.1.2 Spikes");
        Button_Group_1 = GameObject.Find("Button Group 1");
        Button_Group_2 = GameObject.Find("Button Group 2");
        Button_Group_3 = GameObject.Find("Button Group 3");
        Button_Group_4 = GameObject.Find("Button Group 4");
        Button_Group_5 = GameObject.Find("Button Group 5");
        All_Button_Groups = GameObject.Find("All Button Groups");
    }
	
	// Update is called once per frame
	void Update () {
        levelOneChallengeHandler();
    }

    void levelOneChallengeHandler()
    {
        loopCounter = LS.loopCounter;
        switch (loopCounter)
        {
            case 0:
                Level1_1_1Spikes.SetActive(true);
                Level1_1_2Spikes.SetActive(false);
                All_Button_Groups.SetActive(false);
                Button_Group_1.SetActive(true);
                break;
            case 1:
                Level1_1_1Spikes.SetActive(false);
                Level1_1_2Spikes.SetActive(true);
                All_Button_Groups.SetActive(false);
                break;
            case 2:
                Level1_1_1Spikes.SetActive(false);
                Level1_1_2Spikes.SetActive(false);
                if (Time.time - timeSinceLastButtonChange > buttonChangeWaitTime)
                {
                    timeSinceLastButtonChange = Time.time;
                    ButtonChangingHandler();
                }
                break;
            default:
                Level1_1_1Spikes.SetActive(false);
                Level1_1_2Spikes.SetActive(false);
                All_Button_Groups.SetActive(false);
                break;
        }
    }

    void ButtonChangingHandler()
    {
        int previousNumber = 0;

        All_Button_Groups.SetActive(true);
        Button_Group_1.SetActive(false);
        Button_Group_2.SetActive(false);
        Button_Group_3.SetActive(false);
        Button_Group_4.SetActive(false);
        Button_Group_5.SetActive(false);
        int randomButton = Random.Range(1, 6);
        
        if(randomButton >= previousNumber)
        {
            randomButton = randomButton + 1 % 6;
        }
        previousNumber = randomButton;
        switch (randomButton)
        {
            case 1:
                Button_Group_1.SetActive(true);
                break;
            case 2:
                Button_Group_2.SetActive(true);
                break;
            case 3:
                Button_Group_3.SetActive(true);
                break;
            case 4:
                Button_Group_4.SetActive(true);
                break;
            case 5:
                Button_Group_5.SetActive(true);
                break;
        }
    } 
}
