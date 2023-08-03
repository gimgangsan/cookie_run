using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public GameObject[] Prefebs;
    public enum ObjectType { IPP, HPP, Giant, Rush, Coin }
    List<GameObject>[] Pools;

    public float cooltime = 0;

    // Start is called before the first frame update
    private void Awake()
    {
        Pools = new List<GameObject>[Prefebs.Length];
        for (int i = 0; i < Prefebs.Length; i++)
        {
            Pools[i] = new List<GameObject>();
        }
        GeneratePattern();
    }

    public GameObject Get(int type)
    {
        GameObject result = null;

        // 만약 생성되었지만 놀고 있는 오브젝트가 있다면 반환
        foreach (GameObject item in Pools[type])
        {
            if (item.activeSelf == false)
            {
                result = item;
                item.SetActive(true);
                return result;
            }
        }

        // 놀고 있는 오브젝트가 없다면 새로 생성해 반환
        result = Instantiate(Prefebs[type]);
        result.transform.parent = gameObject.transform;
        Pools[type].Add(result);
        return result;
    }

    void GeneratePattern()
    {
        GameObject pattern = Get(Random.Range(1, Prefebs.Length));
        pattern.transform.position = new Vector2(15 + pattern.transform.localScale.x, 4);
        cooltime = (pattern.transform.localScale.x/ General.Instance.back.speed) + Random.Range(1f, 3f);
        Invoke("GeneratePattern", cooltime);
    }
}
