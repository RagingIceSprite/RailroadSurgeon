using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public static bool GameIsPaused = false;

    public GameObject MainMenuBehavior;
    public GameObject OptionsObject;
    public GameObject Main_Menu;

    public void Play()
    {
        SceneManager.LoadScene("SampleScene");
        GameIsPaused = false;
    }
    public void Options()
    {
        Debug.Log("Enable: Options");
        OptionsObject.SetActive(true);
        Main_Menu.SetActive(false);
    }

    public void Back()
    {
        OptionsObject.SetActive(false);
        Main_Menu.SetActive(true);
    }
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quitting game...");
    }
}
