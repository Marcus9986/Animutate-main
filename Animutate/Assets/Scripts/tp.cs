using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tp : MonoBehaviour
{

    [SerializeField] Collider2D player;
    Transform p;

    [SerializeField] Collider2D tp1;
    Transform ttp1;

    [SerializeField] Collider2D tp2;
    Transform ttp2;
    public tp tp2script;

    public bool teleport;
    //public bool teleportTo;
    // Start is called before the first frame update
    void Start()
    {
        ttp1 = tp1.transform;
        ttp2 = tp2.transform;
        p = player.transform;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D col){
        if (col.CompareTag("Player") && teleport == false){
            tp2script.teleport = true;
            p.position = ttp2.position;
        }
    }

    private void OnTriggerExit2D(Collider2D col){
        if (col.CompareTag("Player")){
            teleport = false;
        }
    }
}
