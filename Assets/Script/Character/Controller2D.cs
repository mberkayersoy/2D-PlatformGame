using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller2D : MonoBehaviour
{
    [SerializeField] private LayerMask platformLayerMask;
    private Rigidbody2D rb;
    Vector3 velocity;
    public float speedForce = 2.8f;
    public float jumpForce = 4f;	
    public float fallMultiplier = 3f;
    public float lowJumpMultiplier = 2.5f;
    public float dashForce = 5f;
    private float dashCount;
    public float startDashCount;
    private int side;
    float doubleTapTime;
    KeyCode lastKeyCode;
    public float groundBreakerForce = 35f;
    public float dashCooldownTime = 1;
    public float nextDashTime = 0;
    GroundCheck groundCheck;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        groundCheck = GetComponentInChildren<GroundCheck>();
        //boxCollider2D = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        BetterJump();
        PlayerRotation();
        velocity = new Vector3(Input.GetAxis("Horizontal"), 0f);
        transform.position += velocity * speedForce * Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.W) && IsGrounded())
        {
            //rb.velocity = Vector3.up * jumpForce;
            rb.AddForce(transform.up * jumpForce * 100, ForceMode2D.Force);
        }
        if (!groundCheck.isGround)
        {
            DashMechanic();
        }
        if (!groundCheck.isGround && Input.GetKeyDown(KeyCode.S))
        {
            GroundBreaker();
        }
    }

    private void DashMechanic()
    {  
        if (side == 0)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                if (doubleTapTime > Time.time && lastKeyCode == KeyCode.A)
                {
                    side = 1;
                }
                else
                {
                    doubleTapTime = Time.time + 0.5f;
                }

                lastKeyCode = KeyCode.A;
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
               if (doubleTapTime > Time.time && lastKeyCode == KeyCode.D)
                {
                    side = 2;
                }
                else
                {
                    doubleTapTime = Time.time + 0.5f;
                }

                lastKeyCode = KeyCode.D;
            }
        }
        else
        {
            if (dashCount <= 0)
            {
                side = 0;
                dashCount = startDashCount;
                rb.velocity = Vector2.zero;
            }
            else
            {
                dashCount -= Time.deltaTime;
                
                if (side == 1 && Time.time > nextDashTime)
                {
                    rb.velocity = Vector2.left * dashForce;
                    nextDashTime = Time.time + dashCooldownTime;
                }
                else if (side == 2 && Time.time > nextDashTime)
                {
                    rb.velocity = Vector2.right * dashForce;
                    nextDashTime = Time.time + dashCooldownTime;
                }
            }

        }
        /*if (Time.time > nextDashTime)
        {   
            rb.AddForce(transform.right * dashForce, ForceMode2D.Impulse); 
            nextDashTime = Time.time + dashCooldownTime;
        }*/
        
    }
    private void GroundBreaker()
    {
        rb.AddForce(-transform.up * groundBreakerForce, ForceMode2D.Impulse);
    }

    private void BetterJump()
    {
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (rb.velocity.y > 0 && !Input.GetKey(KeyCode.W))
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }

    private bool IsGrounded()
    {
        return transform.Find("GroundCheck").GetComponent<GroundCheck>().isGround;
        /*float extraHeightTest = 0.01f;
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider2D.bounds.center, 
        boxCollider2D.bounds.size, 0f, Vector2.down, extraHeightTest, platformLayerMask);
        return raycastHit.collider != null;*/
    }
    private void PlayerRotation()
    {
        if (Input.GetAxisRaw("Horizontal") == -1)
        {
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
            //weaponTransform.Rotate(0f, 180f, 0f);
        }
        else if (Input.GetAxisRaw("Horizontal") == 1)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            //weaponTransform.Rotate(0f, 0f, 0f);
        }
    }

}