using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour, IObjectSpeed
{
    public float speed;
    Vector2 startpos;
    // Start is called before the first frame update
    void Start()
    {
        startpos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Movement(speed);
        if (transform.position.x <= -21.99452)
        {
            transform.position = startpos;
        }
    }
    public void Movement(float speed)
    {
        transform.Translate(new Vector2(-1, 0) * speed * Time.deltaTime);
    }
}