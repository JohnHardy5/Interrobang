using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HintText : MonoBehaviour {

    private Text hintText;
    private GameManager gm;

	// Use this for initialization
	void Start () {
        hintText = GetComponent<Text>();
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
