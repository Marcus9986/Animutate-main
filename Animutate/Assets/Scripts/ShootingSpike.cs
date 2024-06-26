using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingSpike : MonoBehaviour
{

    [SerializeField] Transform spike;
    [SerializeField] float x_displacement;
    [SerializeField] float y_displacement;
    [SerializeField] float x_speed;
    [SerializeField] float y_speed;
    public bool start_moving = true;
    float startx;
    float starty;
    Vector3 start_pos;
    // Start is called before the first frame update
    void Start()
    {
        startx = spike.position.x;
        starty = spike.position.y;
        start_pos = spike.position;

        if (x_displacement > 0 && x_speed < 0){
            x_speed = -x_speed;
        } if(y_displacement > 0 && y_speed < 0){
            y_speed = -y_speed;
        }

        if (x_displacement < 0 && x_speed > 0){
            x_speed = -x_speed;
        } if(y_displacement < 0 && y_speed > 0){
            y_speed = -y_speed;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (start_moving){
            if (x_displacement > 0 ){
                if (spike.position.x < startx + x_displacement ){
                    spike.Translate(Time.deltaTime*x_speed, 0, 0);
                } 

                 

                if (spike.position.x >= (startx + x_displacement) && x_displacement != 0) {
                    spike.position = start_pos;
                }
                
            }

            if (y_displacement > 0){
                if (spike.position.y < starty + y_displacement ){
                    spike.Translate(0,Time.deltaTime*y_speed, 0);
                }
                if (spike.position.y >= (starty + y_displacement)&& y_displacement != 0){
                    spike.position = start_pos;
                }
            
            }

            if (x_displacement < 0){

                if (spike.position.x > startx + x_displacement ){
                    // spike.position.x += new Vector3(0.0f + x_displacement, 0.0f, 0.0f);
                    spike.Translate(Time.deltaTime*x_speed, 0, 0);
                } 
                

                if (spike.position.x <= (startx + x_displacement) && x_displacement != 0){
                    spike.position = start_pos;
                }
                
            }

            if (y_displacement < 0)
            {
                if (spike.position.y > starty + y_displacement)
                {
                    spike.Translate(0, Time.deltaTime * y_speed, 0);
                }
                
                if (spike.position.y <= (starty + y_displacement)&& y_displacement != 0){
                    spike.position = start_pos;
                }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player"){
            start_moving = true;
        }
    }

}
