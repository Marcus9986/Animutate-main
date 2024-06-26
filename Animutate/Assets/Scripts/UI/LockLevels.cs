using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockLevels : MonoBehaviour
{
    private void Awake()
    {
        Debug.Log("reset");
        DontDestroyOnLoad(this.gameObject);
        PlayerPrefs.DeleteAll();
    }
}
