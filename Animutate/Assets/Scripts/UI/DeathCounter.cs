using System;
using UnityEngine;
using TMPro;

 
public class DeathCounter : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI m_Object;
    
    void Start()
    {
        if (PlayerPrefs.GetInt("Deaths") > 100)
            m_Object.text = "Total Deaths: " + PlayerPrefs.GetInt("Deaths").ToString() + "\n That's alot of deaths...";
        else
            m_Object.text = "Total Deaths: " + PlayerPrefs.GetInt("Deaths").ToString();
    }
}