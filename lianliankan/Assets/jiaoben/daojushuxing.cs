using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class daojushuxing : MonoBehaviour
{
    public int shiyongcishu;
    Text wenben;
    private void Start()
    {
        wenben = GetComponentInChildren<Text>();
        wenben.text = shiyongcishu.ToString();
    }
}
