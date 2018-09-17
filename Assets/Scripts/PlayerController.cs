using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public GameObject GameManager;
    public GameObject MainCamera;

	// Use this for initialization
	void Start () {
        GameManager = GetComponent<GameObject>();
        MainCamera = GetComponent<GameObject>();
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log(Input.GetAxis("Horizontal"));
	}
}
