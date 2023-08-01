using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IPlayerAbility
{
    public float hp = 100;
    public float EnlargeScale = 2;
    public float FastScale = 4;

    private int JumpCount = 0;
    private Rigidbody2D rigid;
    private CapsuleCollider2D PlayerCollider;
    private Animator Animator;
    private bool IsJumping = false;
    private bool IsEnlarged = false;

    // Start is called before the first frame update
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        PlayerCollider = GetComponent<CapsuleCollider2D>();
        Animator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
        Slide();

        
    }

    public void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && JumpCount < 2)
        {
            JumpCount += 1;
            rigid.velocity = new Vector2(0, 25);
            Animator.Play("PlayerJumping");
        }
    }

    public void Slide()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            float yScale = (IsEnlarged) ? EnlargeScale / 2 : 0.5f;
            transform.localScale = new Vector2(transform.localScale.x, yScale);
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            float yScale = (IsEnlarged) ? EnlargeScale : 1f;
            transform.localScale = new Vector2(transform.localScale.x, yScale);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Platform"))
        {
            JumpCount = 0;
            Animator.Play("PlayerRunning");
        }
    }

    public void RestoreHP(float amount)
    {
        this.hp += amount;
    }

    public void Enlarge()
    {
        IsEnlarged = true;
        transform.localScale = new Vector3(EnlargeScale, EnlargeScale, 1);
        Invoke("Shrink", 5f);
    }

    public void Shrink()
    {
        IsEnlarged = false;
        transform.localScale = new Vector3(1, 1, 1);
    }

    public void GetFast()
    {

    }

    public void GetScore(float amount)
    {

    }
}
