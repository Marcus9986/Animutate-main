using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class SpeedrunTimer : MonoBehaviour
{
    
    [SerializeField] TextMeshProUGUI m_Object;
    // Start is called before the first frame update
    void Start()
    {
        m_Object.text = "" + PlayerPrefs.GetFloat("Timer");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
