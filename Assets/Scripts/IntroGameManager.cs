using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroGameManager : MonoBehaviour {

    public GameObject MainOptions;
    public GameObject Instructions;

	public void StartGame()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadInstructions()
    {
        MainOptions.SetActive(false);
        Instructions.SetActive(true);
    }

    public void LoadMainOptions()
    {
        Instructions.SetActive(false);
        MainOptions.SetActive(true);
    }
}
