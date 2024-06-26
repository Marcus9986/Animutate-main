using System;
using UnityEngine;

public class MovingWater : MonoBehaviour
{
    public float Speed = 5.0f;
    private int startingPoint;
    public Transform[] points;
    private int _index;
    public bool start_moving = true;
    public bool loop = false;
    private bool backwards = false;
    public bool stop_at_start = false;
    public bool stop_at_end = false;
    public bool teleport = false;
    public PlayerController script;
    
    private void Start()
    {
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
                transform.position = points[0].position;
                start_moving = false;
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
            start_moving = false;
            _index = 0;
        }
       
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            start_moving = true;
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
