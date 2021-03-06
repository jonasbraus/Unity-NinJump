using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Character : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] private float rayCastLength;
    [SerializeField] private float rayCastLengthLeftRight;
    private SpriteRenderer renderer;
    private TMP_Text text_applesCount;
    private Animator anim;
    private Rigidbody2D rb;
    private HeartManager heartManager;
    private bool isGrounded = false;
    private float lastTimeDamage = 0;
    private float groundCheckDelay = 1;
    private RaycastHit2D[] hit2D;
    private float hp = 3;
    public GameObject lastCheckPoint;
    private bool canDoubleJump = false;
    private bool isTouchingWall = false;
    private int leftRight = 0;
    private float wallCheckDelay = 0;
    public int applesCount = 0;
    public bool canMove = true;
    private bool jumpRequest = false;
    private CheckPointEnd checkPointEnd;
    private float timeNoDamageStarted;
    private bool noDamage = false;
    private float timeNoGravityStarted;
    private bool noGravity = false;

    private void Awake()
    {
        heartManager = GameObject.Find("Overlay").GetComponent<HeartManager>();
        text_applesCount = GameObject.Find("ApplesLogo").GetComponentInChildren<TMP_Text>();
    }
    
    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        checkPointEnd = GameObject.Find("CheckPoint_End").GetComponent<CheckPointEnd>();
        text_applesCount.text = "0/" + checkPointEnd.neededAppleCount;
        renderer = GetComponent<SpriteRenderer>();
        
        text_applesCount.text = applesCount + "/" + checkPointEnd.neededAppleCount;
    }

    public void RequestJump()
    {
        jumpRequest = true;
    }

    private void Update()
    {
        if(canMove)
        {
            if (noDamage)
            {
                if (Time.time - timeNoDamageStarted > 8)
                {
                    noDamage = false;
                    renderer.color = Color.white;
                }
            }

            if (noGravity)
            {
                if (Time.time - timeNoGravityStarted > 15)
                {
                    noGravity = false;
                    rb.gravityScale = 1;
                    renderer.color = Color.white;
                }
            }
            
            if ((Input.GetButtonDown("Jump") || jumpRequest) && (isGrounded || canDoubleJump || isTouchingWall))
            {
                jumpRequest = false;
                
                if (isGrounded || isTouchingWall)
                {
                    canDoubleJump = true;
                    rb.velocity = Vector2.zero;
                    rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                }
                else
                {
                    canDoubleJump = false;
                    rb.velocity = Vector2.zero;
                    rb.AddForce(Vector2.up * (jumpForce / 1.2f), ForceMode2D.Impulse);
                }

                isGrounded = false;
                isTouchingWall = false;
            }
        }
    }
    
    private void FixedUpdate()
    {
        Vector2 move = new Vector2();
        
        if(canMove)
        {
            move = new Vector2((CrossPlatformInputManager.GetAxis("Horizontal") + Input.GetAxis("Horizontal")) * speed * Time.deltaTime, 0);
            transform.Translate(move);
        }

        hit2D = Physics2D.RaycastAll(transform.position, Vector2.down, rayCastLength);

        if (groundCheckDelay < .01f)
        {
            groundCheckDelay += Time.deltaTime;
        }
        
        if (hit2D.Length > 1 && groundCheckDelay >= .01f)
        {
            isGrounded = true;
            jumpRequest = false;
            groundCheckDelay = 0;
        }
        else if(groundCheckDelay >= .01f)
        {
            isGrounded = false;
            groundCheckDelay = 0;
        }

        hit2D = Physics2D.RaycastAll(transform.position, Vector2.left, rayCastLengthLeftRight);

        if (wallCheckDelay < .01f)
        {
            wallCheckDelay += Time.deltaTime;
        }

        if (hit2D.Length > 1 && wallCheckDelay >= .01f && (Input.GetAxis("Horizontal") < 0 || CrossPlatformInputManager.GetAxis("Horizontal") < 0))
        {
            isTouchingWall = true;
            leftRight = 0;
            wallCheckDelay = 0;
        }
        else
        {
            hit2D = Physics2D.RaycastAll(transform.position, Vector2.right, rayCastLengthLeftRight);
            if (hit2D.Length > 1 && wallCheckDelay >= .01f && (Input.GetAxis("Horizontal") > 0 || CrossPlatformInputManager.GetAxis("Horizontal") > 0))
            {
                isTouchingWall = true;
                leftRight = 1;
                wallCheckDelay = 0;
            }
            else if(wallCheckDelay >= .01f)
            {
                isTouchingWall = false;
                wallCheckDelay = 0;
            }
        }

        if(Time.time - lastTimeDamage > .4f)
        {
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
            
            if (!isGrounded)
            {
                SetAnimationState(2);
            }
        }

        hit2D = Physics2D.RaycastAll(transform.position, Vector2.down, rayCastLength + 1f);
        if (hit2D.Length > 1)
        {
            if (hit2D[1].collider.gameObject.GetComponent<InvisibleBlock>())
            {
                hit2D[1].collider.gameObject.GetComponent<InvisibleBlock>().Trigger();
            }
        }
        
        hit2D = Physics2D.RaycastAll(transform.position, Vector2.down, -rayCastLength - 1f);
        if (hit2D.Length > 1)
        {
            if (hit2D[1].collider.gameObject.GetComponent<MovingPlatform>())
            {
                hit2D[1].collider.gameObject.GetComponent<MovingPlatform>().Trigger();
            }
        }
    }

    public void RegisterCheckPoint(GameObject checkPoint)
    {
        lastCheckPoint = checkPoint;
    }

    public void GetDamage(float amount)
    {
        if(!noDamage)
        {
            SetAnimationState(3);
            if (Time.time - lastTimeDamage > 1)
            {
                hp -= amount;
            }

            heartManager.UpdateHearts(hp);
            if (hp <= 0)
            {
                Die();
            }

            lastTimeDamage = Time.time;
        }
    }

    private void Die()
    {
        transform.position = lastCheckPoint.transform.position + Vector3.back;
        hp = 3;
        heartManager.UpdateHearts(hp);
    }

    private void SetAnimationState(int state)
    {
        anim.SetInteger("Value", state);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<Item>())
        {
            other.gameObject.GetComponent<Item>().Trigger();
            switch (other.gameObject.GetComponent<Item>().itemType)
            {
                case ItemType.Apple:
                    applesCount++;
                    text_applesCount.text = applesCount + "/" + checkPointEnd.neededAppleCount;
                    break;
                case ItemType.Cherry:
                    applesCount += 5;
                    text_applesCount.text = applesCount + "/" + checkPointEnd.neededAppleCount;
                    break;
                case ItemType.Melon:
                    noDamage = true;
                    timeNoDamageStarted = Time.time;
                    renderer.color = new Color(1, 1, 1, .4f);
                    break;
                case ItemType.Banana:
                    rb.gravityScale = .4f;
                    noGravity = true;
                    timeNoDamageStarted = Time.time;
                    renderer.color = Color.gray;
                    break;
            }
        }
    }
}
