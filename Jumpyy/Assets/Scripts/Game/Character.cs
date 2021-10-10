using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] private float rayCastLength;
    private Animator anim;
    private Rigidbody2D rb;
    [SerializeField] private HeartManager heartManager;

    private bool isGrounded = false;
    private float lastTimeDamage = 0;

    private float groundCheckDelay = 1;

    private RaycastHit2D[] hit2D;

    private float hp = 3;

    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Vector2 newVelocity = rb.velocity;
            newVelocity.y = 0;
            rb.velocity = newVelocity;
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isGrounded = false;
        }
    }
    
    private void FixedUpdate()
    {
        Vector2 move = new Vector2(Input.GetAxis("Horizontal") * speed * Time.deltaTime, 0);
        transform.Translate(move);

        hit2D = Physics2D.RaycastAll(transform.position, Vector2.down, rayCastLength);

        if (groundCheckDelay < 1)
        {
            groundCheckDelay += Time.deltaTime;
        }
        
        if (hit2D.Length > 1 && groundCheckDelay >= 1)
        {
            isGrounded = true;
            groundCheckDelay = 0;
        }
        

        if(Time.time - lastTimeDamage > .4f)
        {
            if (!isGrounded)
            {
                SetAnimationState(2);
            }

            if (move.x > 0)
            {
                if (isGrounded)
                {
                    SetAnimationState(1);
                }

                Vector2 scale = transform.localScale;
                scale.x = 1;
                transform.localScale = scale;
            }
            else if (move.x < 0)
            {
                if (isGrounded)
                {
                    SetAnimationState(1);
                }

                Vector2 scale = transform.localScale;
                scale.x = -1;
                transform.localScale = scale;
            }
            else if (isGrounded)
            {
                SetAnimationState(0);
            }
        }
    }

    public void GetDamage(float amount)
    {
        SetAnimationState(3);
        lastTimeDamage = Time.time;
        hp -= amount;
        heartManager.UpdateHearts(hp);
    }

    private void SetAnimationState(int state)
    {
        anim.SetInteger("Value", state);
    }
}
