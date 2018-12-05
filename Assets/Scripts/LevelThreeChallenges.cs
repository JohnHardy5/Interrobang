using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelThreeChallenges : MonoBehaviour {

    private LoopingScript LS;
    private int loopCounter;
    private GameObject Level3_0_1GameObjects;
    private GameObject Level3_0_2GameObjects;
    private GameObject Level3_0_3GameObjects;

    public GameObject LoopyBoi;

    // Use this for initialization
    void Start () {
        Level3_0_1GameObjects = GameObject.Find("Level 3.0.1 GameObjects");
        Level3_0_2GameObjects = GameObject.Find("Level 3.0.2 GameObjects");
        Level3_0_3GameObjects = GameObject.Find("Level 3.0.3 GameObjects");
        LS = LoopyBoi.GetComponent<LoopingScript>();
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
                Level3_0_1GameObjects.SetActive(true);
                Level3_0_2GameObjects.SetActive(false);
                Level3_0_3GameObjects.SetActive(false);
                break;
            case 1:
                Level3_0_1GameObjects.SetActive(false);
                Level3_0_2GameObjects.SetActive(true);
                Level3_0_3GameObjects.SetActive(false);
                break;
            case 2:
                Level3_0_1GameObjects.SetActive(false);
                Level3_0_2GameObjects.SetActive(false);
                Level3_0_3GameObjects.SetActive(true);
                break;
            default:
                Level3_0_1GameObjects.SetActive(false);
                Level3_0_2GameObjects.SetActive(false);
                Level3_0_3GameObjects.SetActive(false);
                break;
        }
    }
}
