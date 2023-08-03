using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour, IPlayerAbility
{
    [Range(0,100)] public float hp = 100;
    public float EnlargeScale = 2;
    public GameObject ScoreUI;
    public ParticleSystem RunningParticle;
    public Slider slider;
    public Image sliderFill;
    public bool IsEnlarged = false;
    public GameObject GameOverManu;

    private int JumpCount = 0;
    private Rigidbody2D rigid;
    private CapsuleCollider2D PlayerCollider;
    private Animator Animator;
    private int CurrentScore = 0;
    private bool alive = true;

    private Background back;

    // Start is called before the first frame update
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        PlayerCollider = GetComponent<CapsuleCollider2D>();
        Animator = GetComponent<Animator>();
        slider.maxValue = hp;
        back = GameObject.Find("Background").GetComponent<Background>();
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
        Slide();

        hp -= Time.deltaTime;
        slider.value = hp;
        sliderFill.color = new Color(1 - slider.value / slider.maxValue, slider.value / slider.maxValue, 0);

        if (Input.GetKeyDown(KeyCode.P))
        {
            GetScore(100);
        }

        if(hp<=0 && alive)
        {
            Time.timeScale = 0;
            GameOverManu.SetActive(true);
            alive = false;
        }
    }

    public void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && JumpCount < 2)
        {
            JumpCount += 1;
            rigid.velocity = new Vector2(0, 25);
            Animator.Play("PlayerJumping");
            RunningParticle.Stop();
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
            RunningParticle.Play();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Item"))
        {
            collision.GetComponent<ItemINF>().effecacy();
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

    public void GetFast(float speed)
    {
        back.speed = speed;
    }

    public void GetScore(int amount)
    {
        int NewScore = CurrentScore + amount;
        CurrentScore = NewScore;
        ScoreUI.GetComponent<Text>().text = NewScore.ToString();
    }

    public void GameReset()
    {
        alive = true;
        hp = slider.maxValue;
        Time.timeScale = 1;
    }
}
