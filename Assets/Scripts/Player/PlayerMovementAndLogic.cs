using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovementAndLogic : MonoBehaviour
{
    // mobile movement
    private bool isMobile = true;
    private bool moveLeft;
    private bool moveRight;
    private float jumpHeight = 18f;
    public float moveSpeed = 9f;

 

    // Assign these in the Inspector by dragging the UI Button GameObjects into the slots

    private Rigidbody2D rb;
    private float dirX;

    void Start()
    {
        moveLeft = false;
        moveRight = false;
        rb = GetComponent<Rigidbody2D>();
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

    }

    

    public void PerformJump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
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
