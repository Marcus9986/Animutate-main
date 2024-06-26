using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private int playAgainScene;
    [SerializeField] private int PlayGameScene;

    public void PlayGame(){
        SceneManager.LoadScene(PlayGameScene);
    }

    public void playAgain()
    {
        SceneManager.LoadScene(playAgainScene);
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

    public void QuitGame(){
        Debug.Log("Quit");
        Application.Quit();
        
    }
}
