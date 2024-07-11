using UnityEngine;
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable All

// todo:
// - improve camera tracking                Done
// - improve ground & water detection       Done
// - implement Coyote Time                  Done
// - implement jump buffering
// - fish
//   - implement swimming mechanic          Done
//   - implement jumping out of water       Done
//   - rotate fish when swimming
// - spider
//   - implement grappling hook mechanic    Done

public class PlayerController : MonoBehaviour
{
    private Animator _animator;
    private static readonly int _Grounded = Animator.StringToHash("isGrounded");
    private BoxCollider2D _boxCollider;
    private LayerMask _groundLayer;
    private LayerMask _waterLayer;

    private float _horizontal;
    private bool _isFacingRight = true;
    private bool _inWater;
    
    private float _coyoteTime = 0.075f;
    private float _coyoteTimeCounter;
    
    public bool shouldRespawn;
    public string currAnimal;
    public int num_unlocked = 2;
    private string[] _unlockedAnimals = {
        "Hare",
        "Frog",
        "Fish",
        "Spider"
    };
    public bool rp;

    // Fundamental Methods
    private void Start()
    {
        currAnimal = "Hare";
        _animator = GetComponent<Animator>();
        _boxCollider = GetComponent<BoxCollider2D>();
        _groundLayer = LayerMask.GetMask("Ground");
        _waterLayer = LayerMask.GetMask("Water");
    }
    
    private void Update()
    {
        UpdateAnimator();
        
        // Coyote Time
        if (CollidingWithGround())
        {
            _coyoteTimeCounter = _coyoteTime;
        }
        else
        {
            _coyoteTimeCounter -= Time.deltaTime;
        }
        
        // Jump Buffering
        
        PollInput();
    }

    private void PollInput()
    {
        // TODO:
        // check if certain animals are unlocked before changing the current animal
        // possibly use a hash to index an array corresponding to each animal (true or false)
        
        if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.H))
        {
            currAnimal = "Hare";
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.J))
        {
            if(num_unlocked >= 2)
                currAnimal = "Frog";
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.K))
        {
            if(num_unlocked >= 3)
                currAnimal = "Fish";
        }
        if (Input.GetKeyDown(KeyCode.Alpha4) || Input.GetKeyDown(KeyCode.L))
        {
            if(num_unlocked >= 4)
                currAnimal = "Spider";
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            Respawn();
            PlayerPrefs.SetInt("Deaths", PlayerPrefs.GetInt("Deaths") - 1);
        }
    }

    private void UpdateAnimator()
    {
        _animator.SetBool(_Grounded, IsGrounded());

        foreach (var e in _unlockedAnimals)
        {
            _animator.SetBool(e, e == currAnimal);
        }

        Flip();
    }

    private void Flip()
    {
        _horizontal = Input.GetAxis("Horizontal");

        if ((_isFacingRight && _horizontal < 0.0f) || (!_isFacingRight && _horizontal > 0.0f))
        {
            _isFacingRight = !_isFacingRight;
            var transformCopy = transform;
            var localScale = transformCopy.localScale;
            localScale.x *= -1.0f;
            transformCopy.localScale = localScale;
        }
    }

    private bool CollidingWithGround()
    {
        var point = (Vector2)transform.position - (Vector2)transform.up * transform.localScale.y;
        Vector2 size;
        if (currAnimal != "Fish")
        {
            size = new Vector2(_boxCollider.size.x - 0.05f, 0.1f);
        }
        else
        {
            size = new  Vector2(_boxCollider.size.x - 0.15f, 0.1f);
        }
        return Physics2D.OverlapBox(point, size, 0.0f, _groundLayer);
    }

    public bool IsGrounded()
    {
        return _coyoteTimeCounter > 0.0f;
    }
    
    public bool InWater()
    {
        var point = (Vector2)transform.position;
        var offset = new Vector2(0.0f, -0.65f);
        var size = _boxCollider.size;
        return Physics2D.OverlapBox(point + offset, size, 0.0f, _waterLayer);
    }
    
    public void Respawn()
    {
        shouldRespawn = true;
    }

    // private void OnTriggerEnter2D(Collider2D col){
    //     if (col.CompareTag("rewind"))
    //     {
    //         rp = true;
    //         Debug.Log("rewinding");
    //     } else
    //     {
    //         rp = false;
    //         Debug.Log("not rewinding");
    //     }
    // }
}