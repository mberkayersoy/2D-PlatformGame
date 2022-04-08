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
    public float jumpForce = 7f;	
    public float fallMultiplier = 3f;
    public float lowJumpMultiplier = 2.5f;
    public float dashForce = 5f;
    public float groundBreakerForce = 35f;
    public float dashCooldownTime = 1;
    public float nextDashTime = 0;
    float direction;
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

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = Vector3.up * jumpForce;
            
        }
        if (!groundCheck.isGround && Input.GetKeyDown(KeyCode.LeftShift))
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
        if (Time.time > nextDashTime)
        {
            rb.AddForce(transform.right * dashForce, ForceMode2D.Impulse); 
            nextDashTime = Time.time + dashCooldownTime;
        }
        
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
        else if (rb.velocity.y > 0 && !Input.GetButton("Jump"))
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
            direction = -1;
        }
        else if (Input.GetAxisRaw("Horizontal") == 1)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);    
            direction = 1;
        }
    }
}