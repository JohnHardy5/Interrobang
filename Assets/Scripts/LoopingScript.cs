using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopingScript : MonoBehaviour {

    public bool isLoopingSection;

    private GameManager GM;
    private FirstPersonController PC;
    private bool hasBeenTriggered = false;

    // Use this for initialization
    void Start()
    {
        GM = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        PC = GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!hasBeenTriggered && !isLoopingSection)
        {
            PC.Teleport();
        }
        hasBeenTriggered = true;
    }
}
