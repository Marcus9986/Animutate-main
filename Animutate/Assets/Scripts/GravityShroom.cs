using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;
public class GravityShroom : MonoBehaviour
{
    private bool gravity_power;
    private Transform player;
    private Rigidbody2D playerbody;
    [SerializeField] Transform shroom;
    private BoxCollider2D shroombody;
    SpriteRenderer sprite;
    Light2D light;
    public float duration = 15.0f;
    private float power_up_time;
    bool _powerUsed = false;
    Vector3 _startPos;
    public PlayerController script;
    private bool grav_on;
    private bool two_powerups;
    private Vector2 start_size;
    private float offset = 0;

    // Start is called before the first frame update
    void Start()
    {
        light = GetComponent<Light2D>();
        sprite = GetComponent<SpriteRenderer>();
        _startPos = shroom.position;
        power_up_time = duration;
        shroombody = shroom.GetComponent<BoxCollider2D>();
        start_size = shroombody.size;
    }

    // Update is called once per frame
    void Update()
    {
        if (gravity_power)
        {
            shroom.position = player.position;
            power_up_time -= Time.deltaTime;
            if (power_up_time < 0)
            {
                shroom.position = _startPos;
                shroombody.size = new Vector2(1,1);
                sprite.enabled = true;
                gravity_power = false;
                _powerUsed = false;
                power_up_time = duration;
                if (grav_on)
                {
                    if (script.currAnimal == "Fish")
                        offset = 0.2f;
                    else if (script.currAnimal == "Spider")
                        offset = 0.45f;
                    player.localScale = new Vector3(player.localScale.x, 1, 1);
                    player.Translate(0,1,0);
                    playerbody.gravityScale = 3;
                    playerbody.velocity = new Vector2(0,0);
                    shroombody.size = start_size;
                    grav_on = false;
                }
                
            }else if (5.0f < power_up_time && power_up_time < 6.0f ){
                light.intensity = 1.0f;
            } else if (4.0f < power_up_time && power_up_time < 5.0f ) {
                light.intensity = 1.76f;
            }else if (3.0f < power_up_time && power_up_time < 4.0f ){
                light.intensity = 1.0f;
            } else if (2.0f < power_up_time && power_up_time < 3.0f ) {
                light.intensity = 1.76f;
            }else if (1.0f < power_up_time && power_up_time < 2.0f ){
                light.intensity = 1.76f;
            } else if (0.8f < power_up_time && power_up_time < 1.0f ) {
                light.intensity = 1.34f;
            }else if (0.6f < power_up_time && power_up_time < 0.8f ){
                light.intensity = 1.0f;
            } else if (0.4f < power_up_time && power_up_time < 0.6f ) {
                light.intensity = 1.76f;
            }else if (0.2f < power_up_time && power_up_time < 0.4f ){
                light.intensity = 1.0f;
            }else if (0.0f < power_up_time && power_up_time < 0.2f ) {
                light.intensity = 1.76f;
            }
        }
        
        if (Input.GetKeyDown("q"))
        {
            if (grav_on && gravity_power)
            {
                if (script.currAnimal == "Fish")
                    offset = 0.2f;
                else if (script.currAnimal == "Spider")
                    offset = 0.45f;
                player.localScale = new Vector3(player.localScale.x, 1, 1);
                player.Translate(0,1 + offset,0);
                playerbody.gravityScale = 3;
                playerbody.velocity = new Vector2(0,0);
                grav_on = false;
                Debug.Log("1");
            }
            else if (! grav_on && gravity_power)
            {
                if (script.currAnimal == "Fish")
                    offset = -0.2f;
                else if (script.currAnimal == "Spider")
                    offset = -0.45f;
                player.localScale = new Vector3(player.localScale.x, -1, 1);
                playerbody.gravityScale = -3;
                player.Translate(0,-1 + offset,0);
                playerbody.velocity = new Vector2(0,0);
                grav_on = true;
                Debug.Log("2");
            }

        }
        //if (Input.GetKey("z"))
            //Time.timeScale = 0.5f;
        //else
            //Time.timeScale = 1;

        

    }
    
    private void LateUpdate()
    {
        if (script.shouldRespawn || two_powerups)
        {
            shroom.position = _startPos;
            shroombody.size = start_size;
            sprite.enabled = true;
            gravity_power = false;
            power_up_time = duration;
            two_powerups = false;
            if (player && grav_on)
            {
                if (script.currAnimal == "Fish")
                    offset = 0.2f;
                else if (script.currAnimal == "Spider")
                    offset = 0.45f;
                player.localScale = new Vector3(player.localScale.x, 1, 1);
                player.Translate(0,1+offset,0);
                playerbody.gravityScale = 3;
                playerbody.velocity = new Vector2(0,0);
                Debug.Log("3");
            }
        _powerUsed = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D col){
        if (col.CompareTag("Player") && !_powerUsed)
        {
            gravity_power = true;
            grav_on = false;
            player = col.transform;
            playerbody = col.GetComponent<Rigidbody2D>();
            shroombody.size = new Vector2(2,2);
            light.enabled = true;
            sprite.enabled = false;
            _powerUsed = true;
            Debug.Log("4");
        } else if (col.CompareTag("PowerUp"))
        {
            if(gravity_power)
                two_powerups = true;
        }
    }
    
}
