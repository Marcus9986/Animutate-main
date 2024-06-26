using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class videos : MonoBehaviour
{

    public VideoPlayer vid;
    // Start is called before the first frame update
    void Start()
    {
        vid.url = System.IO.Path.Combine(Application.streamingAssetsPath,"MenuVideo.mp4");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
