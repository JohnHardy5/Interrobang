using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadEndLevel : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            LoadGame();
        }
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("EndScene");
    }
}
