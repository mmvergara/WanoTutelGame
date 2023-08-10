using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovementAndLogic : MonoBehaviour
{
    // mobile movement
    private bool isMobile = false;
    private bool moveLeft;
    private bool moveRight;
    private float jumpHeight = 18f;
    public float moveSpeed = 9f;
    

    private Rigidbody2D rb;
    private float dirX;

    // Sound effect
    [SerializeField] private AudioSource jumpSoundEffect;

    // Animations
    private Animator anim;
    private enum MovementState { idle, running, falling, jumping }
    private MovementState state = MovementState.idle;
    private SpriteRenderer sprite;
    void Start()
    {
        moveLeft = false;
        moveRight = false;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        if (isMobile)
        {
            MovePlayerMobile();
        } else
        {
            dirX = Input.GetAxisRaw("Horizontal");
        }

        if (Input.GetButtonDown("Jump"))
        {
            PerformJump();
        }

        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);
        UpdateAnimations(dirX);
    }

    

    public void PerformJump()
    {
        jumpSoundEffect.Play();
        rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
     
    }


    // Animations
    private void UpdateAnimations(float dirX)
    {
        // If player is on the move
        if (dirX != 0f)
        {
            state = MovementState.running;
            // if player going left
            if (dirX < 0f)
            {
                sprite.flipX = true;
            }

            // if player going right
            if (dirX > 0f)
            {
                sprite.flipX = false;
            }
        }
        else
        {
            state = MovementState.idle;
        }
        if (rb.velocity.y > .1f) state = MovementState.jumping;
        else if (rb.velocity.y < -.1f) state = MovementState.falling;
        anim.SetInteger("state", (int)state);
    }



    // Mobile Controls
    public void Jump()
    {
        PerformJump();
    }
    public void PointerLeftDown()
    {
        Debug.Log("moveLeft");
        moveLeft = true;
    }
    public void PointerRightDown()
    {
        Debug.Log("moveRRRRt");
        moveRight = true;
    }

    public void PointerControlsUp()
    {
        moveLeft = false;
        moveRight = false;
    }

    public void MovePlayerMobile()
    {
        if (moveLeft)
        {
            dirX = -1;
        }
        else if (moveRight)
        {
            dirX = 1;
        }
        else
        {
            dirX = 0;
        }
    }





}
