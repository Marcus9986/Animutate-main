using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseMenu : MonoBehaviour
{
    // Start is called before the first frame update

    public bool gameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject animals;
    public GameObject rewind;
    public PlayerController player;

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

        if (! gameIsPaused && player.rp == true){
            rewind.SetActive(true);
            Debug.Log("show rewind");
        } else {
            rewind.SetActive(false);
            Debug.Log("hiding rewind f");
        }


    }

    public void resume()
    {
        Debug.Log("resuming");
        pauseMenuUI.SetActive(false);
        animals.SetActive(true);
        if (player.rp == true){
            rewind.SetActive(true);
            Debug.Log("show rewind from pause");
        }
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    public void pause()
    {
        pauseMenuUI.SetActive(true);
        animals.SetActive(false);
        rewind.SetActive(false);
        Debug.Log("hiding rewind from pause");
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