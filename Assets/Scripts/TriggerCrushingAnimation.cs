using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCrushingAnimation : MonoBehaviour {
    public Animator anim;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) anim.SetTrigger("StartAnimation");
    }
}
