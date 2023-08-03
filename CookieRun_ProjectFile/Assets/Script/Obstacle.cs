using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
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
                gameObject.SetActive(false);
            }
        }
    }
}
