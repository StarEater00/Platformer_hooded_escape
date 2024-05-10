using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography;
using Unity.Mathematics;
using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Assertions.Must;
using UnityEngine.Rendering;
using Vector3 = UnityEngine.Vector3;
public class Hood_Script : MonoBehaviour
{
    private float Horizontal;
    private float yground;
    [SerializeField] private float speed;
    private float JumpingPower = 9f;
    private bool isFacingRight = true;
    private bool DoubleJump = true;
    
    [SerializeField] private Animator animator,particle_animator;
    
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform GroundCheck;
    [SerializeField] private LayerMask groundLayer;

    [SerializeField] private GameObject particle;
    [SerializeField] private ParticleSystem dust,jump_trail;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    
        Horizontal = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("speed",Mathf.Abs(Horizontal));
        particle.SetActive(false);
        
        
        // if (Input.GetButton("Jump"))
        //     {        
        //         trail.enabled = true;
        //     }
        // else
        //     {
        //         trail.enabled = false;
        //     }
        Flip();
        Jump();
        decreased_gravity();
        part_system();
       
        
        //particles_animation();
        
        

        
    }
            
        
       
    void FixedUpdate()
    {
        rb.velocity = new UnityEngine.Vector2(Horizontal * speed ,rb.velocity.y);
        
    }
    
    private bool IsGrounded()
    {
        
        return Physics2D.OverlapCircle(GroundCheck.position,0.2f,groundLayer);
      
    }

    private void part_system()
    {   
    
        
        var emission = dust.emission;
        var trail = jump_trail.emission;
        
        if (Horizontal == 1 && IsGrounded() || Horizontal == -1 && IsGrounded()) 
        {   
            emission.enabled = true;
        }
        else
        {
            emission.enabled = false;
        }
        
        // if (Input.GetButton("Jump"))
        if (rb.velocity.y != 0 && !IsGrounded())
            {        
                trail.enabled = true;
            }
        else
            {
                trail.enabled = false;
            }
    }
    private void Flip()
    {   
        Vector3 flip = transform.localScale;
        var emission = dust.emission;
        
        if (Horizontal == -1) 
        {   
            
            //emission.enabled = true;
            
            if (isFacingRight)
                {
                    
                    flip.x = -1f;
                    isFacingRight = false;
                }            
        }

       if (Horizontal == 1)
        {   //emission.enabled = true;
            if (!isFacingRight)
              {
                    flip.x =1f;
                    isFacingRight =true;

                }
        }
       
        transform.localScale = flip;
    }

    private void Jump()
    {
        if (IsGrounded())
        {
            animator.SetBool("isJumping",false);
            animator.SetBool("isFalling",false);
        }
        if (!IsGrounded() && rb.velocity.y > 0f)
        {
            animator.SetBool("isJumping",true);
            animator.SetBool("isFalling",false);
        }
        if (!IsGrounded() && rb.velocity.y < 0f)
        {
            animator.SetBool("isFalling",true);
            animator.SetBool("isJumping",false);
        }
        //if (Vertical == -1)
        if (IsGrounded() && Input.GetButtonDown("Jump"))
        
        {
            rb.velocity = new UnityEngine.Vector2(rb.velocity.x, JumpingPower);
                DoubleJump = true;
                   
        }
        if (rb.velocity.y > 1f && Input.GetButtonUp("Jump"))
        {
            rb.velocity = new UnityEngine.Vector2(rb.velocity.x,JumpingPower *0.5f);

        }
        if (DoubleJump && Input.GetButtonDown("Jump") && !IsGrounded())
        {
            rb.velocity =new UnityEngine.Vector2(rb.velocity.x,JumpingPower);
            DoubleJump = false;
        }
    }
    private void decreased_gravity() 
    {
    if (rb.velocity.y < -1f && Input.GetKey(KeyCode.LeftShift))
        {
            rb.gravityScale = .01f;
        }
    if (rb.velocity.y > 0f || Input.GetKeyUp(KeyCode.LeftShift))
        {
            rb.gravityScale = 3f;
        }
            
        
    }   
    private void particles_animation()
    {
        if (IsGrounded())
        {   
            //UnityEngine.Vector2 player_position = (transform.position.x, transform.position.y + 10);
            particle.GetComponent<Animator>().enabled=true;
            particle.GetComponent<SpriteRenderer>().enabled = true;
            
            if (rb.velocity.x == 0f) 
                {
                     if (IsGrounded())
        {   
            if (rb.velocity.x == 0f) 
                {
                     particle.GetComponent<Animator>().enabled=true;
                     particle.GetComponent<SpriteRenderer>().enabled = true;
                
            if (particle_animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= .9f)
            {
                particle.GetComponent<Animator>().enabled=false;
                particle.GetComponent<SpriteRenderer>().enabled = false;
                particle_animator.Play("walking",0,0f);
            }
            }
        }
        // if (!IsGrounded())
        //     {particle.GetComponent<Animator>().enabled=false;
        //     particle.GetComponent<SpriteRenderer>().enabled = false;
           // }   
        
        if (particle_animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= .9)
                 {
                     particle_animator.Play("walking",0,0f);
                    
                 }
        if (Input.GetButtonDown("Jump"))
        {
            particle_animator.Play("jumping",0,0f);
            particle.GetComponent<Animator>().enabled=true;
                particle.GetComponent<SpriteRenderer>().enabled = true;
             if (particle_animator.GetCurrentAnimatorStateInfo(0).normalizedTime <= .9f)
                
                particle.GetComponent<Animator>().enabled=true;
                particle.GetComponent<SpriteRenderer>().enabled = true;
        }
                
            if (particle_animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= .9f)
            {
                particle.GetComponent<Animator>().enabled=false;
                particle.GetComponent<SpriteRenderer>().enabled = false;
                particle_animator.Play("walking",0,0f);
            }
            }
        }
        // if (!IsGrounded())
        //     {particle.GetComponent<Animator>().enabled=false;
        //     particle.GetComponent<SpriteRenderer>().enabled = false;
           // }   
        
        if (particle_animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= .9)
                 {
                     particle_animator.Play("walking",0,0f);
                    //particle.transform.position = GroundCheck.position;
                 }
        if (Input.GetButtonDown("Jump"))
        {
            particle_animator.Play("jumping",0,0f);
            particle.GetComponent<Animator>().enabled=true;
                particle.GetComponent<SpriteRenderer>().enabled = true;
             if (particle_animator.GetCurrentAnimatorStateInfo(0).normalizedTime <= .9f)
                
                particle.GetComponent<Animator>().enabled=true;
                particle.GetComponent<SpriteRenderer>().enabled = true;
        }
    }
  
}
    