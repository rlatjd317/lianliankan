using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class jishiqi : MonoBehaviour
{
    Image shijiantiao;
    Text shijiantiaowenben;
    float morenshijian;
    public float daojishi;
    private void Start()
    {
        shijiantiao = GameObject.Find("shijiantiao/shijian").GetComponent<Image>();
        shijiantiaowenben = GameObject.Find("shijiantiao/wenben").GetComponent<Text>();
        morenshijian = 60;
        daojishi = morenshijian;
    }
    public bool jishikaishi;
    public void kaishi()
    {
        jishikaishi = true;
    }
    private void Update()
    {
        if (jishikaishi)
        {
            shijiantiaowenben.transform.localScale = Vector3.one;

            daojishi -= Time.deltaTime;
            shijiantiaowenben.text = daojishi.ToString("f2");
            shijiantiao.fillAmount = daojishi / morenshijian;
            if (daojishi < 20)
            {
                shijiantiaowenben.color = Color.red;
            }
            if (daojishi <= 0)
            {
                jishikaishi = false;
                shijiantiaowenben.transform.localScale = Vector3.zero;
                FindAnyObjectByType<youxiguanliqi>().shifouguoguan.text = "Ê§°Ü";
                FindAnyObjectByType<youxiguanliqi>().shibai = true;
            }
        }
    }

}
