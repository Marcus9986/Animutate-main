using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
public class Timer : MonoBehaviour
{
    
    [SerializeField] TextMeshProUGUI m_Object;

    private float _seconds = 0.0f;
    private int _minutes = 0;
    // Start is called before the first frame update
    void Start()
    {
        m_Object.text = "" + _minutes + ": " + string.Format("{0:0.00}", _seconds);
    }

    // Update is called once per frame
    void Update()
    {
        _seconds += Time.deltaTime;
        if (_seconds >= 60f)
        {
            _minutes += 1;
            _seconds = 0f;
        }
        PlayerPrefs.SetFloat("Timer", _seconds + 60 * _minutes);
        m_Object.text = "" + _minutes + ":" + string.Format("{0:0.00}", _seconds);
    }
}
