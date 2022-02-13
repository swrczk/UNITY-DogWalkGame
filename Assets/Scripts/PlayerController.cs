using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public AudioClip JumpClip;
    public float HeroSpeed;
    public float JumpForce;
    public Transform GroundTester;
    public LayerMask GroundLayerMask;
    public Transform StartPoint;

    Animator animator;
    Rigidbody2D rgBody;
    CapsuleCollider2D collider;

    LifesManager lifesManager;
    SceneManager sceneManager;
    bool dirRight = true;
    float extraHeight = .01f;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rgBody = GetComponent<Rigidbody2D>();
        collider = GetComponent<CapsuleCollider2D>();
        lifesManager = GameObject.Find("Manager").GetComponent<LifesManager>();
        sceneManager = GameObject.Find("Manager").GetComponent<SceneManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rgBody == null) return;

        HorizontalMove();
        VerticalMove();
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
        RaycastHit2D raycast = Physics2D.BoxCast(collider.bounds.center, collider.bounds.size, 0f, Vector2.down, extraHeight, GroundLayerMask);
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

    public void RestartHero()
    {
        gameObject.transform.position = StartPoint.position;
        lifesManager.LoseLife();
    }

    public void FailGame()
    {
        FreezePlayer();
        Destroy(rgBody);
        sceneManager.FinishGame(false);
    }

    public void EndGame()
    {
        Jump();
        FreezePlayer();
        Destroy(rgBody);
        Invoke("CallEndGameCanvas", 0.5f);
    }

    void CallEndGameCanvas()
    {
        sceneManager.FinishGame(true);
    }

    void FreezePlayer()
    {
        rgBody.AddForce(new Vector2(0f, -JumpForce));
        rgBody.constraints = RigidbodyConstraints2D.FreezeAll;
        animator.SetFloat("speed", 0f);
    }
}