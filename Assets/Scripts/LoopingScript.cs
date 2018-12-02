using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopingScript : MonoBehaviour {

    public bool isLoopingSection;

    private GameManager GM;
    private FirstPersonController PC;
    public GameObject SpawnPoint;
    private Vector3 SpawnLocation;
    public GameObject HallwayFloor;
    public GameObject HallwayWall;
    private Vector3 HallwayFloorPosition;
    private Vector3 HallwayWallPosition;
    private Vector3 PlayerPosition;
    private float playerOffsetZ;
    private float playerOffsetY;
    // Use this for initialization
    void Start()
    {
        GM = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        PC = GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonController>();
        SpawnLocation = SpawnPoint.transform.position;
        HallwayFloorPosition = HallwayFloor.transform.position;
        HallwayWallPosition = HallwayWall.transform.position;
        PlayerPosition = PC.transform.position;
    }

    void Update()
    {
        double playerWidth = 0.97999999;
        playerOffsetZ = (float)(Mathf.Abs(PC.transform.position.z) - HallwayFloorPosition.z);
        playerOffsetY = (float)(Mathf.Abs(PC.transform.position.y) - HallwayFloorPosition.y - playerWidth);
    }

    private void OnTriggerEnter(Collider other)
    {
        Vector3 SpawnLocationOffset = new Vector3(SpawnLocation.x, SpawnLocation.y + playerOffsetY, SpawnLocation.z + playerOffsetZ);
        if (!isLoopingSection)
        {
            PC.Teleport(SpawnLocationOffset);
        }
    }
}
