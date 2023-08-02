using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class General : MonoBehaviour
{
    private static General instance = null;

    public Player player;
    public Background back;

    void Awake()
    {
        if (null == instance)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }

        this.player = GameObject.Find("Player(test)").GetComponent<Player>();
        this.back = GameObject.Find("Background").GetComponent<Background>();
    }

    public static General Instance
    {
        get
        {
            if (null == instance)
            {
                return null;
            }
            return instance;
        }
    }

}
