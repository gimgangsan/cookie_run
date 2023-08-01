using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour, ItemINF
{
    SpriteRenderer sprite;
    ParticleSystem ItemPickingParticle;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        ItemPickingParticle = GetComponent<ParticleSystem>();
    }

    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Player"))
        {
            sprite.enabled = false;
            ItemPickingParticle.Play();
            effecacy();
        }
    }
}
