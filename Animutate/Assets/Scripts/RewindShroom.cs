using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEditor;

public class RewindShroom : MonoBehaviour
{
    bool rewind_power;
    Transform player;
    [SerializeField] Transform shroom;
    SpriteRenderer sprite;
    private BoxCollider2D shroombody;
    Light2D light;
    [SerializeField] Transform rewind_Light;
    public float duration = 30.0f;
    public float rewind = 15.0f;
    private float power_up_time;
    bool power_used = false;
    Vector3 start_pos;
    Vector3 rewind_pos;
    Queue<Vector3> myQueue = new Queue<Vector3>();
    public PlayerController script;
    private bool two_powerups;
    private Vector2 start_size;
    public PauseMenu pm;



    // MAYBE ADD (COULD HAVE COOL PUZZLES IF NOT ADDED, OR COULD HAVE COOL ONES WITHOUT) make the rewind position reset once you use the power up
    // DONE -------  make the starting position of the rewind light reset once duration ends. 
    // make rewind light start as off before picking up shroom.


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
        if (rewind_power)
        {
            myQueue.Enqueue(player.position);
            rewind_Light.position = rewind_pos;
            shroom.position = player.position;
            power_up_time -= Time.deltaTime;
            if (power_up_time < 0)
            {
                shroom.position = start_pos;
                sprite.enabled = true;
                rewind_power = false;
                script.rp = false;
                rewind_Light.position = start_pos;
                power_up_time = duration;
                shroombody.size = start_size;
                myQueue = new Queue<Vector3>();
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
            }

            if (duration - power_up_time > rewind && ! pm.gameIsPaused){

                rewind_pos = myQueue.Dequeue();
            }
            //Debug.Log(power_up_time);
            //Debug.Log(myQueue.Dequeue());

            if (Input.GetKeyDown("q"))
        {
            player.position = rewind_pos;
            //Debug.Log("tele");
        }

        }



    }
    
    private void LateUpdate()
    {
        if (script.shouldRespawn || two_powerups)
        {
            shroom.position = start_pos;
            shroombody.size = start_size;
            rewind_Light.position = start_pos;
            sprite.enabled = true;
            rewind_power = false;
            script.rp = false;
            power_up_time = duration;
            two_powerups = false;
            shroombody.size = start_size;
            myQueue = new Queue<Vector3>();
        }
       
    }

    private void OnTriggerEnter2D(Collider2D col){
        if (col.CompareTag("Player") && !power_used)
        {
            rewind_power = true;
            player = col.transform;
            light.enabled = true;
            sprite.enabled = false;
            shroombody.size = new Vector2(2,2);
            rewind_pos = player.position;
            script.rp = true;
        } else if (col.CompareTag("PowerUp"))
        {
            two_powerups = true;
        }
    }
}
