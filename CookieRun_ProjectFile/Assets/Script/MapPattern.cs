using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapPattern : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x <= -(transform.localScale.x/2)-10)
        {
            gameObject.SetActive(false);
        }
    }
}
