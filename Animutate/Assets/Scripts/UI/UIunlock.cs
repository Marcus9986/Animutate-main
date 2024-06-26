using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Image = UnityEngine.UIElements.Image;

public class UIunlock : MonoBehaviour
{
    // Start is called before the first frame update
    
    public PlayerController script;
    public GameObject ui;
    public int animal_num;
    

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (script.num_unlocked >= animal_num)
        {
            ui.SetActive(true);
        }
    }

}
