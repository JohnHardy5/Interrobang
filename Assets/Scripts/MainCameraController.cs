using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraController : MonoBehaviour {

    public GameObject GameManager;
    private Transform CameraTransform;

	// Use this for initialization
	void Start () {
        GameManager = GetComponent<GameObject>();
        CameraTransform = this.transform;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public bool RotateHorizontal(float turnRate)
    {
        return true;
    }
}
