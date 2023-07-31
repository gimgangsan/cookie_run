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

    // Start is called before the first frame update
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && JumpCount < 2)
        {
            JumpCount += 1;
            rigid.velocity = new Vector2(0, 25);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("lol");
        if (collision.collider.CompareTag("Platform"))
        {
            JumpCount = 0;
        }
    }

    public void RestoreHP(float amount)
    {
        this.hp += amount;
    }

    public void Enlarge()
    {
        transform.localScale = new Vector3(EnlargeScale, EnlargeScale, 1);
    }

    public void GetFast()
    {

    }

    public void GetScore(float amount)
    {

    }
}
