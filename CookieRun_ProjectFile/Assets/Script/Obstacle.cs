using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour, IObjectSpeed
{

	// Update is called once per frame
	void Update()
	{
		Movement(General.Instance.back.speed);
		
		if (transform.position.x <= -12)
		{
			Destroy(gameObject);
		}
		
	}
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
			Player player = collision.GetComponent<Player>();
			if (General.Instance.back.speed < 38 && player.IsEnlarged == false)
			{
				player.hp -= 10;
			}
			else
			{
				Destroy(gameObject);
			}
		}
	}
	public void Movement(float speed)
	{
		transform.Translate(new Vector2(-1, 0) * speed * Time.deltaTime);
	}

}
