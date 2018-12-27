using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadPlayTime : MonoBehaviour {

	// Use this for initialization
	void Start () {
        if (PlayerData.PlayTime != null)
            GetComponent<Text>().text = "You finished in: " + PlayerData.PlayTime;
	}
}
