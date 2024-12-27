using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    protected Rigidbody2D rb;
    protected Animator animator;
    protected Damageable damageable;
    protected TouchingDirections touchingDirections;

    public virtual bool CanMove
    {
        get
        {
            return animator.GetBool(AnimationStrings.canMove);
        }
    }

    protected virtual void Awake()
    {
        // Khởi tạo tham chiếu đến Rigidbody2D
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        touchingDirections = GetComponent<TouchingDirections>();
        damageable = GetComponent<Damageable>();
    }

    protected virtual void Update()
    {

    }

    public virtual void OnInit()
    {

    }

    public virtual void OnDespawn()
    {

    }

    public void OnHit(int damage, Vector2 knockback)
    {
        rb.velocity = new Vector2(knockback.x, rb.velocity.y + knockback.y);
    }
}
