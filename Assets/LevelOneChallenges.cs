using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelOneChallenges : MonoBehaviour {

    public GameObject LevelSpikes;
    public GameObject LoopyBoi;
    LoopingScript LS;
    double loopCounter;

    // Use this for initialization
    void Start () {
        LS = LoopyBoi.GetComponent<LoopingScript>();
    }
	
	// Update is called once per frame
	void Update () {
        
        loopCounter = LS.loopCounter;
        Debug.Log(loopCounter);
        // Debug.Log(loopCounter);
        if (loopCounter == 1)
        {
            LevelSpikes.SetActive(true);
        } else
        {
            LevelSpikes.SetActive(false);
        }
            
        
        
    }
}
