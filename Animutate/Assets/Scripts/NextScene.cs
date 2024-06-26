using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    [SerializeField] private int Scene_to_load;

    int loadNextScene;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player"){
            if(SceneManager.GetActiveScene().buildIndex <= 6 && PlayerPrefs.GetInt("LevelPassed") < SceneManager.GetActiveScene().buildIndex)
                PlayerPrefs.SetInt("LevelPassed", SceneManager.GetActiveScene().buildIndex);
            SceneManager.LoadScene(Scene_to_load);
        }
    }
}
