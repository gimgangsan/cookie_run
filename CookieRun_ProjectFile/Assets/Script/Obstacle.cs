using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour, IObjectSpeed
{
    Background back;

    // Start is called before the first frame update
    void Start()
    {
        back = GameObject.Find("Background").GetComponent<Background>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement(back.speed);
        if (transform.position.x <= -12)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Player player = collision.collider.GetComponent<Player>();
            player.hp -= 20;
            Destroy(gameObject);
        }
    }
    public void Movement(float speed)
    {
        transform.Translate(new Vector2(-1, 0) * speed * Time.deltaTime);
    }

}
