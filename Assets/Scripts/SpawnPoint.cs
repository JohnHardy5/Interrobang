using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour {

    public bool isStartSpawn;

    private GameManager GM;
    private bool hasBeenTriggered = false;

	// Use this for initialization
	void Start () {
        GM = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
	}

    private void OnTriggerEnter(Collider other)
    {
        if (!hasBeenTriggered && !isStartSpawn)
        {
            GM.currentLevel++;
            GM.currentIterration = 0;
            GM.SetSpawnLocation(transform.position);
        }
        hasBeenTriggered = true;
    }
}
