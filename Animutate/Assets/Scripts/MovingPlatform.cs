using System;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float Speed = 5.0f;
    public int startingPoint;
    public Transform[] points;
    public int _index;
    public bool start_moving;
    public bool loop = false;
    private bool backwards = false;
    public bool stop_at_start = true;
    public bool stop_at_end = false;
    public bool teleport = false;
    private Collider2D player;
    public PlayerController script;
    private bool started;


    private void Start()
    {

        if (start_moving)
            started = true;
        else
            started = false;
        transform.position = points[startingPoint].position;
        if (teleport)
        {
            stop_at_end = false;
            stop_at_start = false;
            loop = false;
        }
    }

    void Update()
    {
        if(start_moving){
            if (Vector2.Distance(transform.position, points[_index].position) < 0.02f)
            {
                if(!backwards){
                    _index++;
                }else{
                    _index--;
                }

                if(_index == -1){
                    if(stop_at_start )
                        start_moving = false;
                    _index = 0;
                    backwards = false;
                }   
                
                if(!teleport || (teleport && _index != points.Length))
                    if(!loop){
                        if (_index == points.Length){
                            if(stop_at_end)
                                start_moving = false;
                            _index -= 2;
                            backwards = true;
                        }
                    } else {
                        if (_index == points.Length)
                            if(stop_at_end)
                                start_moving = false;
                        _index = 0;
                    }       
            }
            
            if (teleport && _index == points.Length)
            {
                if(player)
                    player.transform.SetParent(null);
                transform.position = points[0].position;
                start_moving = started;
                _index = 0;
            } else
                transform.position = Vector2.MoveTowards(transform.position, points[_index].position, Speed * Time.deltaTime);
        }
    }
    
    private void LateUpdate()
    {
        if (script.shouldRespawn)
        {
            transform.position = points[0].position;
            start_moving = started;
            _index = 0;
        }
       
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            col.transform.SetParent(transform);
            player = col;
            start_moving = true;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            player = null;
            col.transform.SetParent(null);
        }
    }
    
    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            start_moving = true;
        }
    }
}
