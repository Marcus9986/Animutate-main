using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BWater : MonoBehaviour
{
    
    private TilemapRenderer map;
    private TilemapCollider2D body;

    public buttonPress _button;

    private bool active;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<TilemapCollider2D>();
        map = GetComponent<TilemapRenderer>();
        active = map.enabled;
    }

    // Update is called once per frame
    void Update()
    {
        if (_button.activated)
        {
            map.enabled = !active;
            body.enabled = !active;
        }
        else
        {
            map.enabled = active;
            body.enabled = active;
        }
            

    }
}
