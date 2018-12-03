using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HintText : MonoBehaviour {

    private Text hintText;
    private GameManager gm;
    private string hint_1_0 = "Level 1 iterration 0 hint";
    private string hint_1_1 = "Level 1 iterration 1 hint";
    private string hint_1_2 = "Level 1 iterration 2 hint";
    private string hint_2_0 = "Level 2 iterration 0 hint";
    private string hint_2_1 = "Level 2 iterration 1 hint";
    private string hint_2_2 = "Level 2 iterration 2 hint";
    private string hint_3_0 = "Level 3 iterration 0 hint";
    private string hint_3_1 = "Level 3 iterration 1 hint";
    private string hint_3_2 = "Level 3 iterration 2 hint";

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
