using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class xuanzhongsucai : MonoBehaviour
{
    public bool xuanzhong;
    public bool yixiaochu;

    private void Update()
    {
        if (xuanzhong)
        {
            transform.GetComponent<Image>().color = Color.yellow;
        }
        else
        {
            transform.GetComponent<Image>().color = Color.white;
        }
    }
}
