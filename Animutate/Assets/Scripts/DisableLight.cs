using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class DisableLight : MonoBehaviour
{

    private Light2D light;
    public buttonPress _button;

    private bool active;
    // Start is called before the first frame update
    void Start()
    {
        light = GetComponent<Light2D>();
        active = light.enabled;
    }

    // Update is called once per frame
    void Update()
    {
        if (_button.activated)
            light.enabled = !active;
        else
            light.enabled = active;

    }
}
