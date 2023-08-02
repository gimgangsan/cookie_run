using UnityEngine;

public class Item : MonoBehaviour, ItemINF
{
    PoolManager Pool;
    protected float Speed;
    protected Player player;
    ParticleSystem ItemPickParticle;
    Rigidbody2D rigid;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        Pool = GameObject.Find("Pool Manager").GetComponent<PoolManager>();
        Speed = GameObject.Find("Background").GetComponent<Background>().speed;
        player = GameObject.Find("Player(test)").GetComponent<Player>();
    }

    void Update()
    {
        rigid.velocity = new Vector2(-Speed, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            effecacy();
            ItemPickParticle = Pool.Get(PoolManager.ObjectType.IPP).GetComponent<ParticleSystem>();
            ItemPickParticle.transform.position = transform.position;
            ItemPickParticle.Play();
            gameObject.SetActive(false);
        }
    }

    public virtual void effecacy() 
    {
        
    }
}
