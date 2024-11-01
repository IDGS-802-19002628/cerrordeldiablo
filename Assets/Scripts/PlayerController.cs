using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Tilemaps;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 150f;
    public Vector2 maxVelocity = new Vector2(60, 100);
    public float jetSpeed = 200f;
    public bool standing;
    public float airSpeedMultiplier = .3f;
    public float standingThreeshold = 4f;

    private Rigidbody2D body2D;
    private SpriteRenderer renderer2D;
    private PlayerMovie playerMoving;
    private Animator animator;
    private bool facingRight;

    void Start()
    {
        body2D = GetComponent<Rigidbody2D>();
        renderer2D = GetComponent<SpriteRenderer>();
        playerMoving = GetComponent<PlayerMovie>();
        animator = GetComponent<Animator>();

        if (transform.localScale.x < 0f)
        {
            facingRight = false;
        }else if (transform.localScale.x > 0f)
        {
            facingRight = true;
        }
    }

    void Update()
    {
        var absVleX = Mathf.Abs(body2D.velocity.x);
        var absVley = Mathf.Abs(body2D.velocity.y);

        if (absVleX <= standingThreeshold)
        {
            standing = true;
        }
        else
        {
            standing = false;
        }

        var forceX = 0f;
        var forceY = 0f;

        if (playerMoving.moving.x != 0)
        {
            if (absVleX < maxVelocity.x)
            {
                var newSpeed = speed * playerMoving.moving.x;
                forceX = standing ? newSpeed : (newSpeed * airSpeedMultiplier);

                //renderer2D.flipX = forceX < 0;
                Flip();
            }
            animator.SetInteger("AnimState",1);
        }
        else
        {
            animator.SetInteger("AnimState", 0);
        }

        if (playerMoving.moving.y > 0)
        {
            if (absVley < maxVelocity.y)
            {
                forceY = jetSpeed * playerMoving.moving.y;
            }
            animator.SetInteger("AnimState", 2);
        }
        else if(absVley > 0 && !standing)
        {
            animator.SetInteger("AnimState", 0);
        }
        body2D.AddForce(new Vector2(forceX, forceY));
    }
    // se usa un colaider que de estar como trigger
  /*  private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Item")
        {
            Destroy(collision.gameObject);
        }
    }*/

    private void Flip()
    {
        facingRight = !facingRight;
        float localScaleX = playerMoving.moving.x * -1f;
        localScaleX = localScaleX * -1f;
        transform.localScale = new Vector3(localScaleX, transform.localScale.y, transform.localScale.z);
    }
}

