using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonPress : MonoBehaviour
{
    [SerializeField] GameObject inactive;
    [SerializeField] GameObject inactiveup;
    [SerializeField] GameObject inactivedown;
    [SerializeField] GameObject active;
    [SerializeField] GameObject activeup;
    [SerializeField] GameObject activedown;
    public PlayerController script;

    public bool activated;
    // Start is called before the first frame update
    void Start()
    {
        inactive.SetActive(true);
        inactiveup.SetActive(true);
        inactivedown.SetActive(false);
        active.SetActive(false);
        activeup.SetActive(false);
        activedown.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {

            if (inactive.activeSelf == true)
            {
                activated = true;
                inactivedown.SetActive(true);
                inactiveup.SetActive(false);
                inactive.SetActive(false); 
                active.SetActive(true);
                activeup.SetActive(false);
                activedown.SetActive(true);
            }
            else if (active.activeSelf == true)
            {
                activated = false;
                activedown.SetActive(true);
                activeup.SetActive(false);
                inactive.SetActive(true); 
                active.SetActive(false);
                inactiveup.SetActive(false);
                inactivedown.SetActive(true);
            }
            
        }
    }
    
    private void LateUpdate()
    {
        if (script.shouldRespawn)
        {
            activated = false;
            activedown.SetActive(true);
            activeup.SetActive(false);
            inactive.SetActive(true); 
            active.SetActive(false);
            inactiveup.SetActive(true);
            inactivedown.SetActive(false);
        }
       
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            if (active.activeSelf == true)
            {
                activedown.SetActive(false);
                activeup.SetActive(true);
            } else if (inactive.activeSelf == true)
            {
                inactivedown.SetActive(false);
                inactiveup.SetActive(true);
            }
        }
    }
}
