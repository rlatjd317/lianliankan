using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class guanqiaguanliqi : MonoBehaviour
{
    public GameObject guanqiaduixiang_yuzhijian;
    GameObject guanqiazu;
    private void Start()
    {
        guanqiazu = GameObject.Find("guanqiazu");
        shengchengguanqia();
    }
    void shengchengguanqia()
    {
        int shengchengshu = 5;
        for (int i = 0; i < shengchengshu; i++) 
        {
            GameObject fuzhiwu = Instantiate(guanqiaduixiang_yuzhijian, guanqiazu.transform);
            fuzhiwu.name = (i + 1).ToString();
            fuzhiwu.transform.Find("wenben").GetComponent<Text>().text = fuzhiwu.name;
          //  fuzhiwu.transform.GetChild(0).GetComponent<Text>().text = fuzhiwu.name;
        }
    }

}
