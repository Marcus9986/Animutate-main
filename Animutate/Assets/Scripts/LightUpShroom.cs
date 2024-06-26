using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightUpShroom : MonoBehaviour
{
    bool light_power;
    Transform player;
    [SerializeField] Transform shroom;
    SpriteRenderer sprite;
    private BoxCollider2D shroombody;
    Light2D light;
    public float duration = 15.0f;
    private float power_up_time;
    bool power_used = false;
    Vector3 start_pos;
    public PlayerController script;
    private bool two_powerups;
    private Vector2 start_size;


    // Start is called before the first frame update
    void Start()
    {
        light = GetComponent<Light2D>();
        sprite = GetComponent<SpriteRenderer>();
        start_pos = shroom.position;
        power_up_time = duration;
        shroombody = shroom.GetComponent<BoxCollider2D>();
        start_size = shroombody.size;
    }

    // Update is called once per frame
    void Update()
    {
        if (light_power)
        {
            shroom.position = player.position;
            power_up_time -= Time.deltaTime;
            if (power_up_time < 0)
            {
                shroom.position = start_pos;
                sprite.enabled = true;
                light_power = false;
                power_up_time = duration;
                shroombody.size = start_size;
            } 
            else if (5.0f < power_up_time && power_up_time < 6.0f ){
                light.intensity = 1.0f;
            } else if (4.0f < power_up_time && power_up_time < 5.0f ) {
                light.intensity = 2.84f;
            }else if (3.0f < power_up_time && power_up_time < 4.0f ){
                light.intensity = 1.0f;
            } else if (2.0f < power_up_time && power_up_time < 3.0f ) {
                light.intensity = 2.84f;
            }else if (1.0f < power_up_time && power_up_time < 2.0f ){
                light.intensity = 1.0f;
            } else if (0.8f < power_up_time && power_up_time < 1.0f ) {
                light.intensity = 2.84f;
            }else if (0.6f < power_up_time && power_up_time < 0.8f ){
                light.intensity = 1.0f;
            } else if (0.4f < power_up_time && power_up_time < 0.6f ) {
                light.intensity = 2.84f;
            }else if (0.2f < power_up_time && power_up_time < 0.4f ){
                light.intensity = 1.0f;
            }else if (0.0f < power_up_time && power_up_time < 0.2f ) {
                light.intensity = 2.84f;
            }
            // Debug.Log("powerup");
        }
    }
    
    private void LateUpdate()
    {
        if (script.shouldRespawn || two_powerups)
        {
            shroom.position = start_pos;
            shroombody.size = start_size;
            sprite.enabled = true;
            light_power = false;
            power_up_time = duration;
            two_powerups = false;
            shroombody.size = start_size;
        }
       
    }

    private void OnTriggerEnter2D(Collider2D col){
        if (col.CompareTag("Player") && !power_used)
        {
            light_power = true;
            player = col.transform;
            light.enabled = true;
            sprite.enabled = false;
            shroombody.size = new Vector2(2,2);
        } else if (col.CompareTag("PowerUp"))
        {
            two_powerups = true;
        }
    }
}
