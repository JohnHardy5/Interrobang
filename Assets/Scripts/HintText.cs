using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HintText : MonoBehaviour {

    private Text hintText;
    private GameManager gm;
    private string hint_1_0 = "Baby Steps";
    private string hint_1_1 = "Baby Steps the Sequel";
    private string hint_1_2 = "Where the button goes, who knows?";
    private string hint_2_0 = "Some jumps require a little SHIFT in Speed";
    private string hint_2_1 = "Some jumps require strafing";
    private string hint_2_2 = "Deception";
    private string hint_3_0 = "Beginning of the end";
    private string hint_3_1 = "Find the six buttons";
    private string hint_3_2 = "Why are you reading the hints, there is a wall of spikes coming at you";

    // Use this for initialization
    void Start () {
        hintText = GetComponent<Text>();
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {
		switch (gm.currentLevel)
        {
            case 1:
                switch (gm.currentIterration)
                {
                    case 0:
                        hintText.text = hint_1_0;
                        break;
                    case 1:
                        hintText.text = hint_1_1;
                        break;
                    case 2:
                        hintText.text = hint_1_2;
                        break;
                }
                break;
            case 2:
                switch (gm.currentIterration)
                {
                    case 0:
                        hintText.text = hint_2_0;
                        break;
                    case 1:
                        hintText.text = hint_2_1;
                        break;
                    case 2:
                        hintText.text = hint_2_2;
                        break;
                }
                break;
            case 3:
                switch (gm.currentIterration)
                {
                    case 0:
                        hintText.text = hint_3_0;
                        break;
                    case 1:
                        hintText.text = hint_3_1;
                        break;
                    case 2:
                        hintText.text = hint_3_2;
                        break;
                }
                break;
            default:
                hintText.text = "";
                break;
        }
	}
}
