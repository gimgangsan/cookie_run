using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public GameObject[] Prefebs;
    public enum ObjectType { IPP, HPP, Giant, Rush, Coin }
    List<GameObject>[] Pools;

    // Start is called before the first frame update
    private void Awake()
    {
        Pools = new List<GameObject>[Prefebs.Length];
        for (int i = 0; i < Prefebs.Length; i++)
        {
            Pools[i] = new List<GameObject>();
        }
    }

    public GameObject Get(ObjectType type)
    {
        GameObject result = null;

        // ���� �����Ǿ����� ��� �ִ� ������Ʈ�� �ִٸ� ��ȯ
        foreach (GameObject item in Pools[(int)type])
        {
            if (item.activeSelf == false)
            {
                result = item;
                item.SetActive(true);
                return result;
            }
        }

        // ��� �ִ� ������Ʈ�� ���ٸ� ���� ������ ��ȯ
        result = Instantiate(Prefebs[(int)type]);
        result.transform.parent = gameObject.transform;
        Pools[(int)type].Add(result);
        return result;
    }
}
