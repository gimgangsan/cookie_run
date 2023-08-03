using UnityEngine;

public class Item : MonoBehaviour, ItemINF
{
    PoolManager Pool;
    protected float Speed;
    ParticleSystem ItemPickParticle;
    Rigidbody2D rigid;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        Pool = GameObject.Find("Pool Manager").GetComponent<PoolManager>();
        Speed = General.Instance.back.speed;
    }

    public virtual void effecacy() 
    {
        ItemPickParticle = Pool.Get(0).GetComponent<ParticleSystem>();
        ItemPickParticle.transform.position = transform.position;
        ItemPickParticle.Play();
        gameObject.SetActive(false);
    }
}
