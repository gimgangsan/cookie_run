using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapPattern : MonoBehaviour
{
    private void OnEnable()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(true);
        }
        transform.position = new Vector2(15 +transform.localScale.x, 4);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector2(-1, 0) * General.Instance.back.speed * Time.deltaTime);
        if (transform.position.x <= -(transform.localScale.x/2)-10)
        {
            gameObject.SetActive(false);
        }
    }
}
