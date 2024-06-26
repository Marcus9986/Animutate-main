using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Disappear : MonoBehaviour
{
    private TilemapRenderer map;
    // Start is called before the first frame update
    void Start()
    {
        map = GetComponent<TilemapRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            map.enabled = false;
        }
    }
    
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            map.enabled = true;
        }
    }
}
