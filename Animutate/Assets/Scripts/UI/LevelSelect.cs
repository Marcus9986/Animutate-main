using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelect : MonoBehaviour
{
    public Button l2, l3, l4, l5, l6,l7;
    public int lp; // level passed

    void Start()
    {
        // PlayerPrefs.DeleteAll();
        lp = PlayerPrefs.GetInt("LevelPassed");
        l2.interactable = false;
        l3.interactable = false;
        l4.interactable = false;
        l5.interactable = false;
        l6.interactable = false;
        l7.interactable = false;
    }

    private void Update()
    {
        lp = PlayerPrefs.GetInt("LevelPassed");
        if(Input.GetKeyDown(KeyCode.Alpha2) && PlayerPrefs.GetInt("LevelPassed") < 1)
            PlayerPrefs.SetInt("LevelPassed",1);
        else if(Input.GetKeyDown(KeyCode.Alpha3) && PlayerPrefs.GetInt("LevelPassed") < 2)
            PlayerPrefs.SetInt("LevelPassed",2);
        else if(Input.GetKeyDown(KeyCode.Alpha4) && PlayerPrefs.GetInt("LevelPassed") < 3)
            PlayerPrefs.SetInt("LevelPassed",3);
        else if(Input.GetKeyDown(KeyCode.Alpha5) && PlayerPrefs.GetInt("LevelPassed") < 4)
            PlayerPrefs.SetInt("LevelPassed",4);
        else if(Input.GetKeyDown(KeyCode.Alpha6) && PlayerPrefs.GetInt("LevelPassed") < 5)
            PlayerPrefs.SetInt("LevelPassed",5);
        else if(Input.GetKeyDown(KeyCode.Alpha7) && PlayerPrefs.GetInt("LevelPassed") < 6)
            PlayerPrefs.SetInt("LevelPassed",6);
        else if(Input.GetKeyDown(KeyCode.Alpha9))
            PlayerPrefs.SetInt("LevelPassed",0);
        switch (lp)
        {
            case 0:
                l2.interactable = false;
                l3.interactable = false;
                l4.interactable = false;
                l5.interactable = false;
                l6.interactable = false;
                l7.interactable = false;
                break;
            case 1:
                l2.interactable = true;
                l3.interactable = false;
                l4.interactable = false;
                l5.interactable = false;
                l6.interactable = false;
                l7.interactable = false;
                break;
            case 2:
                l2.interactable = true;
                l3.interactable = true;
                l4.interactable = false;
                l5.interactable = false;
                l6.interactable = false;
                l7.interactable = false;
                break;
            case 3:
                l2.interactable = true;
                l3.interactable = true;
                l4.interactable = true;
                l5.interactable = false;
                l6.interactable = false;
                l7.interactable = false;
                break;
            case 4:
                l2.interactable = true;
                l3.interactable = true;
                l4.interactable = true;
                l5.interactable = true;
                l6.interactable = false;
                l7.interactable = false;
                break;
            case 5:
                l2.interactable = true;
                l3.interactable = true;
                l4.interactable = true;
                l5.interactable = true;
                l6.interactable = true;
                l7.interactable = false;
                break;
            case 6:
                l2.interactable = true;
                l3.interactable = true;
                l4.interactable = true;
                l5.interactable = true;
                l6.interactable = true;
                l7.interactable = true;
                break;
        }
    }
    
    public void menu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    
    public void LoadLevel(int level){
        SceneManager.LoadScene(level);
    }
    public void tutorial(){
        SceneManager.LoadScene("Tutorial");
    }
    public void speedrun(){
        SceneManager.LoadScene("SpeedRun");
    }

    public void special(){
        SceneManager.LoadScene("Special");
    }

    public void QuitGame(){
        Debug.Log("Quit");
        Application.Quit();
        
    }
}
