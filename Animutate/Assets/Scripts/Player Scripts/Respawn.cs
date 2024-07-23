using UnityEngine;

public class Respawn : MonoBehaviour
{
    public Vector3 _lastCheckpointPosition;
    public PlayerController playerController;
    public bool unlocked_animal = false;
    private bool respawned;
    private Rigidbody2D playerbody;
    

    private void Start()
    {
        if (_lastCheckpointPosition == new Vector3(0,0,0))
            _lastCheckpointPosition = new Vector3(0.0f, -1.5f, 0.0f);
        playerbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (respawned)
        {
            playerController.shouldRespawn = false;
            respawned = false;
        }
    }

    private void LateUpdate()
    {
        if (playerController.shouldRespawn)
        {
            PlayerPrefs.SetInt("Deaths", PlayerPrefs.GetInt("Deaths") + 1);
            playerbody.velocity = new Vector2(0,0);
            transform.position = _lastCheckpointPosition;
            respawned = true;
        }
       
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Death Barrier"))
        {
            playerController.shouldRespawn = true;
        }

        if (col.CompareTag("Campfire") || col.CompareTag("Checkpoint"))
        {
            _lastCheckpointPosition = col.transform.position;
        }

        if (col.CompareTag("Campfire") && !unlocked_animal)
        {
            unlocked_animal = true;
            playerController.num_unlocked++;
            
        }
        
        if (col.CompareTag("Shapeshift") && !unlocked_animal)
        {
            col.enabled = false;
            playerController.num_unlocked++;
            if (playerController.num_unlocked >= 4)
                unlocked_animal = true;

        }
    }
    
}