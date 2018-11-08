using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStick : MonoBehaviour {

    public GameObject player;

    private Quaternion rotation;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            rotation = player.transform.rotation;
            Debug.Log(rotation);
            other.transform.parent = transform;
            player.transform.rotation = rotation;
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
