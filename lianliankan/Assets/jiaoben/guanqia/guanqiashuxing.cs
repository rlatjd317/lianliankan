using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class guanqiashuxing : MonoBehaviour
{
    public bool guoguan;
    GameObject guanqiazu;
    private void Start()
    {
        guanqiazu = GameObject.Find("guanqiazu");
        panduanyiguoguan();
        panduanjiesuo();
    }
    void panduanyiguoguan()
    {
        if (PlayerPrefs.GetString(transform.name, "0") == "1")
        {
            guoguan = true;
        }
    }
    void panduanjiesuo()
    {
        Transform[] quanqiazu = guanqiazu.GetComponentsInChildren<Transform>();
        List<Transform> guanqiazulist = new List<Transform>();

        for (int i = 1; i < quanqiazu.Length; i++)
        {
            if (quanqiazu[i].name != "wenben" && quanqiazu[i].name != "suo")
            {
                guanqiazulist.Add(quanqiazu[i]);
            }
        }
        if (transform.GetSiblingIndex() > 0)
        {
            bool jiesuotiaojian = guanqiazulist[transform.GetSiblingIndex() - 1].GetComponent<guanqiashuxing>().guoguan;
            if (jiesuotiaojian)
            {
                transform.Find("suo").localScale = Vector3.zero;
            }
        }
        else if (transform.GetSiblingIndex() == 0)
        {
            transform.Find("suo").localScale = Vector3.zero;
        }
    }
    public void dianjianniu()
    {
        SceneManager.LoadScene(transform.name);
    }
}
