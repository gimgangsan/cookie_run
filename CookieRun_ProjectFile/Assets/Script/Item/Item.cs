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

    void Update()
    {
        rigid.velocity = new Vector2(General.Instance.back.speed * -1, 0);
    }

    public virtual void effecacy() 
    {
        ItemPickParticle = Pool.Get(PoolManager.ObjectType.IPP).GetComponent<ParticleSystem>();
        ItemPickParticle.transform.position = transform.position;
        ItemPickParticle.Play();
        gameObject.SetActive(false);
    }
}
