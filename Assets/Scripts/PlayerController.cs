using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Reflection;

public enum Direction
{
    Up = 0,
    Down = 1,
    Left = 2,
    Right = 3

}

public class PlayerController : MonoBehaviour
{
    //Outelts
    Rigidbody2D _rigidbody;
    Animator _animator;
    SpriteRenderer _spriteRenderer;
    public Transform[] attackZones;

    // State Tracking
    public Direction facingDirection;

    //Configuration 
    public KeyCode keyUp;
    public KeyCode keyDown;
    public KeyCode keyLeft;
    public KeyCode keyRight;
    public float moveSpeed;


    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float movementSpeed = _rigidbody.velocity.magnitude;
        _animator.SetFloat("speed", movementSpeed);
        if (movementSpeed > 0.1f){
            _animator.SetFloat("movementX", _rigidbody.velocity.x);
            _animator.SetFloat("movementY", _rigidbody.velocity.y);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _animator.SetTrigger("attack");
            int facingDirectionIndex = (int)facingDirection;
            Transform attackZone = attackZones[facingDirectionIndex];
            Collider2D[] hits = Physics2D.OverlapCircleAll(attackZone.position, 0.1f);

            foreach (Collider2D hit in hits)
            {
                print("hit");
                Breakable breakableObject = hit.GetComponent<Breakable>();
                print(breakableObject);
                if (breakableObject)
                {
                    breakableObject.Break();
                    print("break");
                }
            }


        }
    }

    void FixedUpdate()
    {
        if (Input.GetKey(keyUp))
        {
            _rigidbody.AddForce(Vector2.up * moveSpeed, ForceMode2D.Impulse);
        }
        if (Input.GetKey(keyDown))
        {
            _rigidbody.AddForce(Vector2.down * moveSpeed, ForceMode2D.Impulse);
        }
        if (Input.GetKey(keyLeft))
        {
            _rigidbody.AddForce(Vector2.left * moveSpeed, ForceMode2D.Impulse);
        }
        if (Input.GetKey(keyRight))
        {
            _rigidbody.AddForce(Vector2.right * moveSpeed, ForceMode2D.Impulse);
        }

    }
    void LateUpdate()
    {
        if (String.Equals(_spriteRenderer.sprite.name, "zelda1_8"))
        {
            facingDirection = Direction.Up;
        }else if (String.Equals(_spriteRenderer.sprite.name, "zelda1_4"))
        {
            facingDirection = Direction.Down;
        }else if (String.Equals(_spriteRenderer.sprite.name, "zelda1_10"))
        {
            facingDirection = Direction.Left;
        }else if (String.Equals(_spriteRenderer.sprite.name, "zelda1_6"))
        {
            facingDirection = Direction.Right;
        }
    }

}
