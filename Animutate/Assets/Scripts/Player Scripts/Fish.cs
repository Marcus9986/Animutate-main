using UnityEngine;
// ReSharper disable All

public class Fish : MonoBehaviour
{
    private PlayerController _playerController;
    private Rigidbody2D _rb;
    
    private float _horizontal;
    private float _vertical;
    private const float Speed = 11.0f;
    private const float JumpingPower = 23.0f;
    private bool _leaped;

    private void Start()
    {
        _playerController = GetComponent<PlayerController>();
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (_playerController.currAnimal != "Fish") return;

        if (_playerController.IsGrounded() && !_playerController.InWater())
        {
            _playerController.currAnimal = "Hare";
            _playerController.Respawn();
            return;
        }
        
        PollInput();
    }

    void PollInput()
    {
        _horizontal = 0;
        _vertical = 0;

        if (Input.GetKey(KeyCode.W))
            _vertical += 1;
        if (Input.GetKey(KeyCode.A))
            _horizontal -= 1;
        if (Input.GetKey(KeyCode.D))
            _horizontal += 1;
        if (Input.GetKey(KeyCode.S))
            _vertical -= 1;
        
        if (_playerController.InWater())
        {
            _leaped = false;
            _rb.velocity = new Vector2(_horizontal * Speed, _vertical * Speed - Time.deltaTime);
        }
        else
        {
            // leap mechanic
            if (transform.localScale.y >= 0.0f)
            {
                if ((_vertical > 0.0f && !_leaped))
                {
                    _leaped = true;
                    _rb.velocity = new Vector2(_rb.velocity.x, JumpingPower * transform.localScale.y);
                }    
                // dive mechanic
                else if (_vertical < 0.0f)
                {
                    _rb.velocity = new Vector2(_rb.velocity.x, _rb.velocity.y - 25.0f * Time.deltaTime * transform.localScale.y);
                }
            }
            else
            {
                if ((_vertical < 0.0f && !_leaped))
                {
                    _leaped = true;
                    _rb.velocity = new Vector2(_rb.velocity.x, JumpingPower * transform.localScale.y);
                }    
                // dive mechanic
                else if (_vertical > 0.0f)
                {
                    _rb.velocity = new Vector2(_rb.velocity.x, _rb.velocity.y - 25.0f * Time.deltaTime * transform.localScale.y);
                }
            }
            // constant downward force while out of water
            _rb.velocity = new Vector2(_horizontal * Speed * 0.5f, _rb.velocity.y - JumpingPower * Time.deltaTime * transform.localScale.y);
        }
    }
}