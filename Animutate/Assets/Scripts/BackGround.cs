using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour


    
{

    public PlayerController script;
    public GameObject background;
    public GameObject[] others;
    public bool isActive;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!background.activeSelf){
            isActive = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {

        if (col.CompareTag("Player") && !isActive)
        {
            background.SetActive(true);
            isActive = true;

            for(int i = 0; i < others.Length; i++)
            {
                others[i].SetActive(false);
            }

        }

    }
    
}
