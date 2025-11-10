using System;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private float animationTriggerOffset = 0.1f;
    private PlayerMovement playerMovementScript;
   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerMovementScript = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerMovementScript.isPlayerDead)
        {
            animator.SetTrigger("Death");
        }     
        else if (playerMovementScript.isHit)
        {
            // I made it this way so that the hit animation is played without interruption.
            animator.SetTrigger("Hit");
            playerMovementScript.hitTimer += Time.deltaTime;

            if (playerMovementScript.hitTimer >= playerMovementScript.hitDuration)
            {
                playerMovementScript.isHit = false;
                playerMovementScript.hitTimer = 0f;
            }
        }
        else
        {
            if (rb.linearVelocityX < -animationTriggerOffset)
            {
                spriteRenderer.flipX = true;
            }
            else if (rb.linearVelocityX > animationTriggerOffset)
            {
                spriteRenderer.flipX = false;
            }
            if (Math.Abs(rb.linearVelocityX) > animationTriggerOffset && Math.Abs(rb.linearVelocityY) < animationTriggerOffset)
            {
                animator.Play("Run");
            }
            else if (rb.linearVelocityY > animationTriggerOffset)
            {
                animator.Play("Jump");
            }
            else if (rb.linearVelocityY < -animationTriggerOffset)
            {
                animator.Play("Falling");
            }
            else
            {
                animator.Play("Idle");
            }
        }
    }

    public void OnPlayerDeath()
    {
        GameManager.Instance.LooseLife(true);
        GameManager.Instance.EnableGameOverScreen();
        Destroy(gameObject);
    }    
}
