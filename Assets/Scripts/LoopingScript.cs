using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopingScript : MonoBehaviour {

    public bool isLoopingSection;

    private GameManager GM;
    private FirstPersonController PC;
    public GameObject SpawnPoint;
    private bool hasBeenTriggered = false;
    private Vector3 SpawnLocation;

    // Use this for initialization
    void Start()
    {
        GM = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        PC = GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonController>();
        SpawnLocation = SpawnPoint.transform.position;
        Debug.Log(PC.transform.position);
        Debug.Log(SpawnLocation);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!hasBeenTriggered && !isLoopingSection)
        {
            PC.Teleport(SpawnLocation);
        }
        hasBeenTriggered = true;
    }
}
