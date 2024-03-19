using System.Collections.Generic;
using UnityEngine;

public class MainController : MonoBehaviour
{
    
    public float movementSpeed;
    public int _index;
    private State _state;

    public List<Sprite> idleSprites = new List<Sprite>();
    private SpriteRenderer _spriteRenderer;
    private Animator _animator;
    private Vector2 _movement = new Vector2();
    private Rigidbody2D _rigidbody2D;

    private enum State
    {
        Idle,
        Front,
        Back,
        Left,
        Right
    }
    
    void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _state = State.Idle;

        _index = 0;
    }

    void Update()
    {

        if (Input.GetKey(KeyCode.W)) {
            _animator.SetBool("Front", true);
        } else if (Input.GetKey(KeyCode.S)) {
            _animator.SetBool("Back", true);
        } else if (Input.GetKey(KeyCode.A)) {
            _animator.SetBool("Left", true);
        } else if (Input.GetKey(KeyCode.D)) {
            _animator.SetBool("Right", true);
        }   
        
        
        if (Input.GetKeyUp(KeyCode.W)) {
            _animator.SetBool("Front", false);
        } else if (Input.GetKeyUp(KeyCode.S)) {
            _animator.SetBool("Back", false);
        } else if (Input.GetKeyUp(KeyCode.A)) {
            _animator.SetBool("Left", false);
        } else if (Input.GetKeyUp(KeyCode.D)) {
            _animator.SetBool("Right", false);
        }   
        
        
        switch (_state)
        {
            case State.Idle:
                _spriteRenderer.sprite = idleSprites[_index];
                break;
            
            case State.Front:
                _index = 0;
                break;
            
            case State.Back:
                _index = 1;
                break;
            
            case State.Left:
                _index = 2;
                break;
            
            case State.Right:
                _index = 3;
                break;
        }
    }
    
    
    
    
    void FixedUpdate()
    {
        _movement.x = Input.GetAxisRaw("Horizontal");
        _movement.y = Input.GetAxisRaw("Vertical");
        
        _movement.Normalize();

        _rigidbody2D.velocity = _movement * movementSpeed;
    }

    void Move()
    {
        
    }
}
