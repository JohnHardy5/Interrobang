using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopingScript : MonoBehaviour {

    private GameManager GM;
    private FirstPersonController PC;
    private Vector3 SpawnLocation;
    private Vector3 HallwayFloorPosition;
    private Vector3 HallwayWallPosition;
    private Vector3 PlayerPosition;
    private float playerOffsetZ;
    private float playerOffsetY;
    private DoorController DC;

    public GameObject HallwayFloor;
    public GameObject HallwayWall;
    public GameObject SpawnPoint;
    public int loopCounter;
    public bool isLoopingSection;
    public GameObject DoorController;
    // Use this for initialization
    void Start()
    {
        GM = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        PC = GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonController>();
        SpawnLocation = SpawnPoint.transform.position;
        HallwayFloorPosition = HallwayFloor.transform.position;
        HallwayWallPosition = HallwayWall.transform.position;
        PlayerPosition = PC.transform.position;
        DC = DoorController.GetComponent<DoorController>();
    }

    void Update()
    {
        if(HallwayFloorPosition.z < 0 && PC.transform.position.z < 0)
        {
            playerOffsetZ = (float)(Mathf.Abs(HallwayFloorPosition.z) - Mathf.Abs(PC.transform.position.z));
        } else
        {
            playerOffsetZ = (float)(Mathf.Abs(PC.transform.position.z) - Mathf.Abs(HallwayFloorPosition.z));
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isLoopingSection && loopCounter < 2)
        {
            DC.CloseDoor();
            Vector3 SpawnLocationOffset = new Vector3(SpawnLocation.x, SpawnLocation.y + playerOffsetY, SpawnLocation.z + playerOffsetZ);
            loopCounter++;
            PC.Teleport(SpawnLocationOffset);
        }
    }
}
