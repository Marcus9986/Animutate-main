using UnityEngine;
// ReSharper disable All

public class Hare : MonoBehaviour
{
    private PlayerController _playerController;
    private Rigidbody2D _rb;
    
    private float _horizontal;
    private const float Speed = 15.0f;
    private const float JumpingPower = 15.0f;

    private void Start()
    {
        _playerController = GetComponent<PlayerController>();
        _rb = GetComponent<Rigidbody2D>();
    }
    
    private void Update()
    {
        if (_playerController.currAnimal != "Hare") return;
        
        // the hare dies in water
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
        
        if (Input.GetButtonDown("Jump") && _playerController.IsGrounded())
        {
            _rb.velocity = new Vector2(_rb.velocity.x, JumpingPower * transform.localScale.y);
        }

        if (Input.GetButtonUp("Jump") && ((_rb.velocity.y > 0.0f && transform.localScale.y == 1) || (_rb.velocity.y < 0.0f && transform.localScale.y == -1)))
        {
            _rb.velocity = new Vector2(_rb.velocity.x, _rb.velocity.y * 0.5f);
        }

        _rb.velocity = new Vector2(_horizontal * Speed, _rb.velocity.y);
    }
}