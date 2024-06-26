using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseMenu : MonoBehaviour
{
    // Start is called before the first frame update

    public static bool gameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject animals;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused)
            {
                resume();
            }
            else
            {
                pause();
            }
        }


    }

    public void resume()
    {
        Debug.Log("resuming");
        pauseMenuUI.SetActive(false);
        animals.SetActive(true);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    public void pause()
    {
        pauseMenuUI.SetActive(true);
        animals.SetActive(false);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

    public void menu()
    {
        Debug.Log("loading menu");
        Time.timeScale = 1f;
        gameIsPaused = false;
        SceneManager.LoadScene("MainMenu");
    }
}