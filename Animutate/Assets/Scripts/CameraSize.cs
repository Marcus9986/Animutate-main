using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSize : MonoBehaviour
{

    [SerializeField] Camera camera;
    public float size;
    public bool zoom = false;
    public bool zoom_in = false;
    public bool zoom_out = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        /*
        if(zoom){
            if(zoom_in && camera.orthographicSize > size){
                camera.orthographicSize -= 0.01f;
                if (camera.orthographicSize <= size){
                    Debug.Log("done zooming out");
                    zoom_in = false;
                    zoom = false;
                }
            }

            else if(zoom_out && camera.orthographicSize < size ){
                camera.orthographicSize += 0.01f;
                if (camera.orthographicSize >= size){
                    Debug.Log("done zooming out");
                    zoom_out = false;
                    zoom = false;
                }
            }
        }
        */
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            /*
            if(camera.orthographicSize > size)
                zoom_in = true;
            else if(camera.orthographicSize < size)
                zoom_out = true;
            zoom = true;
            */
            camera.orthographicSize = size;
        }
    }
}
