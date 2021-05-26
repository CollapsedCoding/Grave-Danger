using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour

{
    //general declarations
    public Rigidbody2D rb;
    //player movement
    public float speed = 10.0f;
    public float jumpForce = 15.0f;
    public float input;
    //grounded check
    bool isGrounded = false;
    public Transform isGroundedChecker;
    public float checkGroundRadius;
    public LayerMask groundLayer;
    //Gravity Variables
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;
    public float rememberGroundedFor;
    float lastTimeGrounded;
    //animation
    public Animator anim;



    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
        GroundCheck();
        BetterJump();
    }
    void Move()

    {
        input = Input.GetAxis("Horizontal");
        float moveBy = input * speed;
        rb.velocity = new Vector2(moveBy, rb.velocity.y);

        if (input != 0)
        {
            anim.SetBool("Moving",true);
        }else{anim.SetBool("Moving",false);}

        if (input<0)
        {
            transform.rotation = Quaternion.Euler(0,180,0);
        }else if (input>0)
        {
            transform.rotation = Quaternion.Euler(0,0,0);
        }
    }
    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.W)&& (isGrounded || Time.time - lastTimeGrounded <= rememberGroundedFor) || Input.GetKeyDown(KeyCode.Joystick1Button0)&& (isGrounded || Time.time - lastTimeGrounded <= rememberGroundedFor))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

    }
    void GroundCheck()
    {
        Collider2D colliders = Physics2D.OverlapCircle(isGroundedChecker.position, checkGroundRadius, groundLayer);
        anim.SetBool("Grounded",isGrounded);
        if (colliders != null)
        {
            isGrounded = true;
        }
        else
        {
            if (isGrounded)
            {
                lastTimeGrounded = Time.time;
            }
            isGrounded = false;
        }
    }
    void BetterJump()
    {
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (rb.velocity.y > 0 && !Input.GetKey(KeyCode.Space))
        {
            rb.velocity += Vector2.up * Physics2D.gravity * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }


    
}




