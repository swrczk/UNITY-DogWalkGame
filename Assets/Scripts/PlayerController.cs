using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float HeroSpeed;
    public float JumpForce;
    public AudioClip JumpClip;
    public Transform GroundTester;
    public LayerMask GroundLayerMask;
    public Transform StartPoint;

    Animator animator;
    Rigidbody2D rgBody;
    CapsuleCollider2D coll;
    bool dirRight = true;
    float extraHeight = .01f;

    void Start()
    {
        animator = GetComponent<Animator>();
        rgBody = GetComponent<Rigidbody2D>();
        coll = GetComponent<CapsuleCollider2D>();
    }

    void Update()
    {
        if (rgBody != null)
        {
            HorizontalMove();
            VerticalMove();
        }
    }

    void HorizontalMove()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("DogDeadBush"))
        {
            rgBody.velocity = Vector2.zero;
            return;
        }
        float horizontalMove = Input.GetAxis("Horizontal");
        animator.SetFloat("speed", Math.Abs(horizontalMove));
        rgBody.velocity = new Vector2(horizontalMove * HeroSpeed, rgBody.velocity.y);

        var turnLeft = horizontalMove < 0 && dirRight;
        var turnRight = horizontalMove > 0 && !dirRight;
        if (turnLeft || turnRight)
        {
            Flip();
        }
    }

    void VerticalMove()
    {
        if (IsJumping() && IsOnGround())
        {
            Jump();
        }
    }

    bool IsOnGround()
    {
        RaycastHit2D raycast = Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, extraHeight, GroundLayerMask);
        // Debug.DrawRay(collider.bounds.center, Vector2.down * (collider.bounds.extents.y + extraHeight), raycast.collider != null ? Color.green : Color.red);
        return raycast.collider != null;
    }

    bool IsJumping()
    {
        float verticalMove = Input.GetAxis("Vertical");
        return Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow) ||
                        Input.GetKeyDown(KeyCode.W);
    }

    void Flip()
    {
        Vector3 heroScale = gameObject.transform.localScale;
        dirRight = !dirRight;
        heroScale.x *= -1;

        gameObject.transform.localScale = heroScale;
    }

    void Jump()
    {
        if (rgBody == null) return;
        rgBody.AddForce(new Vector2(0f, JumpForce));
        animator.SetTrigger("jump");
        AudioSource.PlayClipAtPoint(JumpClip, transform.position);
    }

    void FreezePlayer()
    {
        rgBody.AddForce(new Vector2(0f, -JumpForce));
        rgBody.constraints = RigidbodyConstraints2D.FreezeAll;
        animator.SetFloat("speed", 0f);
    }

    public void NextLevelReaction()
    {
        Jump();
        FreezePlayer();
        Destroy(rgBody);
    }

    public void FailGameReaction()
    {
        if (rgBody != null)
        {
            FreezePlayer();
            Destroy(rgBody);
        }
    }
}