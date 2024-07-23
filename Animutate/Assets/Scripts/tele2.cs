using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tele2 : MonoBehaviour
{

   [SerializeField] Collider2D player;
   Transform p;
    // Start is called before the first frame update
    void Start()
    {
        p = player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("6"))
        {
            p.position = new Vector3(9,34,0);
        }
        if (Input.GetKeyDown("7"))
        {
            p.position = new Vector3(142,-2,0);
        }
        if (Input.GetKeyDown("8"))
        {
            p.position = new Vector3(428,87,0);

        }

        if (Input.GetKeyDown("9"))
        {
            p.position = new Vector3(645,182,0);
        }
    }
}
