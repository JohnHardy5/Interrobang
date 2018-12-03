using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelOneChallenges : MonoBehaviour {

    public GameObject LevelSpikes;
    public GameObject LoopyBoi;
    LoopingScript LS;
    int loopCounter;
    private GameObject Level1_1_1Spikes;
    private GameObject Level1_1_2Spikes;
    private GameObject Button_Group_1;
    private GameObject Button_Group_2;
    private GameObject Button_Group_3;
    private GameObject Button_Group_4;
    private GameObject Button_Group_5;
    private GameObject All_Button_Groups;


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
                All_Button_Groups.SetActive(true);
                break;
            default:
                Level1_1_1Spikes.SetActive(false);
                Level1_1_2Spikes.SetActive(false);
                All_Button_Groups.SetActive(false);
                break;
        }   
    }
}
