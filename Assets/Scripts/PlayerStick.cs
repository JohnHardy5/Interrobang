using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStick : MonoBehaviour {

    public GameObject player;

    private Quaternion playerRot;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            playerRot = player.transform.rotation;
            Debug.Log(playerRot);
            other.transform.parent = transform;
            player.transform.rotation = playerRot * transform.rotation;
            Debug.Log(player.transform.rotation);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            other.transform.parent = null;
        }
    }
}
