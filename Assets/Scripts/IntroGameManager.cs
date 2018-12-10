using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IntroGameManager : MonoBehaviour {

    public GameObject MainOptions;
    public GameObject Instructions;
    public Text playText;

	public void StartGame()
    {
        playText.text = "Loading...";
        SceneManager.LoadScene("MainScene");
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
