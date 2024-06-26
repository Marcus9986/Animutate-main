using UnityEngine;
// ReSharper disable All

public class Spider : MonoBehaviour
{
    [SerializeField] private WebShooter webShooter;
    
    private PlayerController _playerController;
    private Rigidbody2D _rb;

    private float _horizontal;
    private const float Speed = 6.0f;
    
    private void Start()
    {
        _playerController = GetComponent<PlayerController>();
        _rb = GetComponent<Rigidbody2D>();
    }
    
    private void Update()
    {
        if (_playerController.currAnimal != "Spider") return;
        
        if (_playerController.InWater())
        {
            _playerController.Respawn();
            return;
        }
        
        PollInput();
    }

    private void PollInput()
    {
        _horizontal = 0;
        
        if (Input.GetKey(KeyCode.A))
            _horizontal -= 1;
        if (Input.GetKey(KeyCode.D))
            _horizontal += 1;
        
        // cannot move while grapping; can only swing
        if (!webShooter.isGrappling)
            _rb.velocity = new Vector2(_horizontal * Speed, _rb.velocity.y);
        else
            _rb.velocity = new Vector2(_rb.velocity.x, _rb.velocity.y);
    }
}