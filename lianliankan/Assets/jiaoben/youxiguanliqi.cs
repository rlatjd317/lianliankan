using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Mono.Cecil.Cil;

public class youxiguanliqi : MonoBehaviour
{
    public List<GameObject> sucailist = new List<GameObject>();
    GameObject mianban;
    RectTransform mianban_rt;
    GridLayoutGroup mianban_group;
    LineRenderer xiaochuxian;
    Text dangqianguanqia;
    public Text shifouguoguan;
    GameObject kaishimianban;
    Image kaishi_pic;
    Text kaishi_wenben;

    private void Start()
    {
        mianban = GameObject.Find("mianban");
        mianban_rt = mianban.GetComponent<RectTransform>();
        mianban_group = mianban.GetComponent<GridLayoutGroup>();

        xiaochuxian = GameObject.Find("xiaochuxian").GetComponent<LineRenderer>();
        dangqianguanqia = GameObject.Find("dangqianguanqia").GetComponent<Text>();
        dangqianguanqia.text = "¹Ø¿¨£º" + SceneManager.GetActiveScene().name;
        shifouguoguan = GameObject.Find("shifouguoguan").GetComponent<Text>();

        kaishimianban = GameObject.Find("kaishimianban");
        kaishi_pic = GameObject.Find("kaishimianban/tu").GetComponent<Image>();
        kaishi_wenben = GameObject.Find("kaishimianban/wenben").GetComponent<Text>();
    }
 
    int shengchengcishu;
    void shengchengsucai()
    {
        //shengchengcishu = 40;
        shengchengkongsucai();
        for (int i = 0; i < shengchengcishu; i++)
        {
            int suijishu = Random.Range(0, 10);
            GameObject fuzhiwu1 = Instantiate(sucailist[suijishu], mianban.transform);
            fuzhiwu1.name = sucailist[suijishu].name;

            GameObject fuzhiwu2 = Instantiate(sucailist[suijishu], mianban.transform);
            fuzhiwu2.name = sucailist[suijishu].name;
        }



        for (int i = 0; i < charusuoyinlist.Count; i++)
        {
            GameObject fuzhiwu = Instantiate(kong_yuzhijian, mianban.transform);
            fuzhiwu.name = kong_yuzhijian.name;
        //    fuzhiwu.name = "kong" + i.ToString();
            kongsucailist.Add(fuzhiwu);
        }

  //      mianban_rt.sizeDelta = new Vector2(mianban_group.cellSize.x * 10 + mianban_group.spacing.x * 9,
   //        mianban_group.cellSize.y * 
   //         (shengchengcishu + charusuoyinlist.Count / 2) /
   //         10 * 2 + mianban_group.spacing.y * shengchengcishu / 10 * 2);
        daluanshunxu();
        kongsucaipailie();

    }

    public GameObject kong_yuzhijian;
    List<int> charusuoyinlist = new List<int>();
    List<GameObject> kongsucailist = new List<GameObject>();
    void shengchengkongsucai()
    {
        charusuoyinlist.Clear();
        kongsucailist.Clear();
        int hangshu = 0;
        switch (SceneManager.GetActiveScene().name)
        {
            case "1":
                charusuoyinlist.AddRange(new int[] { 0, 1, 8, 9, 10, 11, 18, 19, 60, 61, 68, 69, 70, 71, 78, 79 });
                hangshu = 8;
                mianban_group.constraintCount = 10;
                break;

            case "2":
                charusuoyinlist.AddRange(new int[] { 4, 5, 14, 15, 24, 25, 34, 35, 44, 45, 54, 55, 64, 65, 74, 75 });
                hangshu = 8;
                mianban_group.constraintCount = 10;
                break;
            case "3":
                charusuoyinlist.AddRange(new int[] { 16, 18, 22, 28, 31, 33, 40, 44, 52, 56, 61, 64, 68, 74, 75, 80 });
                hangshu = 8;
                mianban_group.constraintCount = 12;
                break;
            case "4":
                charusuoyinlist.AddRange(new int[] { 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 27, 
                    37, 40, 50, 53, 63, 66, 67, 68, 69, 70, 71, 72, 73, 74, 75, 76 });
                hangshu = 7;
                mianban_group.constraintCount = 13;
                break;
            case "5":
                charusuoyinlist.AddRange(new int[] {});
                hangshu = 7;
                mianban_group.constraintCount = 14;
                break;
        }
        shengchengcishu = mianban_group.constraintCount * hangshu / 2 + mianban_group.constraintCount * hangshu % 2 -
            charusuoyinlist.Count / 2 + charusuoyinlist.Count % 2;

    }
    void kongsucaipailie()
    {
        for (int i = 0; i < kongsucailist.Count; i++)
        {
            kongsucailist[i].transform.SetSiblingIndex(mianban.transform.childCount);
        }
        for (int i = 0; i < kongsucailist.Count; i++)
        {
            kongsucailist[i].transform.SetSiblingIndex(charusuoyinlist[i]);
        }
    }
    void daluanshunxu()
    {
        List<Transform> duixianglist = new List<Transform>();
        Transform[] ziduixiang = mianban.GetComponentsInChildren<Transform>();
        for (int i = 1; i < ziduixiang.Length; i++)
        {
            if (ziduixiang[i].name != "wenben")
            {
               // if (ziduixiang[i].name != "kong")
                {
                    duixianglist.Add(ziduixiang[i]);
                }
            }
        }
     
        int daluancishu = 200;
        for (int i = 0; i < daluancishu; i++)
        {
            int suijishu = Random.Range(0, mianban.transform.childCount);
            duixianglist[suijishu].transform.SetSiblingIndex(0);
        }
    }

    Transform duixiang1;
    Transform duixiang2;
    float jishiqi;
    List<Vector2> zuobiaolist = new List<Vector2>();

    Vector2 zuobiao1;
    Vector2 zuobiao2;
    Vector2 zuobiao3;
    Vector2 zuobiao4;
    bool jiluzuobiao2_1;
    bool jiluzuobiao3_1;
    bool jiluzuobiao3_2;
    float jishiqi_guanqiakaishi;
    bool youxikaishi;
    public bool shibai;
    private void Update()
    {
        if (!youxikaishi)
        {
            jishiqi_guanqiakaishi += Time.deltaTime;
            kaishi_pic.fillAmount = 1 - (jishiqi_guanqiakaishi / 3f);
            kaishi_wenben.text = (3 - jishiqi_guanqiakaishi / 1).ToString("f0");
            if (jishiqi_guanqiakaishi >= 3)
            {
                kaishimianban.transform.localScale = Vector3.zero;
                youxikaishi = true;
                FindAnyObjectByType<jishiqi>().kaishi();
                shengchengsucai();
            }
        }

        if (!youxikaishi || guoguan || shibai) 
        {
            return;
        }
        if (Input.GetMouseButtonDown(0))
        {
            if (kexiaochu || fangdajingzhong)
            {
                return;
            }
            Vector2 shubiaozuobiao = Input.mousePosition;
            RaycastHit2D dianjiduixiang = Physics2D.Raycast(shubiaozuobiao, Vector2.zero, 0, LayerMask.GetMask("sucai"));
            RaycastHit2D gongneng = Physics2D.Raycast(shubiaozuobiao, Vector2.zero, 0, LayerMask.GetMask("zhadan"));

            if (dianjiduixiang.transform != null)
            {
                dianjiduixiang.transform.GetComponent<xuanzhongsucai>().xuanzhong = true;

                if (duixiang1 == null)
                {
                    duixiang1 = dianjiduixiang.transform;
                }
                else if (duixiang2 == null)
                {
                    duixiang2 = dianjiduixiang.transform;
                }

                if (duixiang1 != null && duixiang2 != null)
                {
                    panduan();
                }
            }
            else if (gongneng.transform != null)
            {

            }
            else
            {
                sucaixuanzhongfuwei();
                duixiang1 = null;
                duixiang2 = null;
            }
            
        }
        if (kexiaochu)
        {
            switch (panduanbiaoshi)
            {
                
                case 1:
                    xunhuan = 1;

                    float julicha1 = Vector2.Distance(zuobiaolist[xunhuan], xiaochuxian.GetPosition(xunhuan));

                    if (julicha1 > 0.2)
                    {
                        huaxian();
                    }
                    else
                    {
                        xiaochu();
                    }
                    break;
                case 2:
                    xunhuan = 1;
                    float julicha2_1 = Vector2.Distance(zuobiaolist[xunhuan], xiaochuxian.GetPosition(xunhuan));

                    if (julicha2_1 > 0.2)
                    {
                        huaxian();
                    }
                    else if(julicha2_1 <=0.2)
                    {
                        if (!jiluzuobiao2_1)
                        {
                            jiluzuobiao2_1 = true;
                            xiaochuxian.positionCount = 3;
                            xiaochuxian.SetPosition(xunhuan, zuobiaolist[xunhuan]);
                            xiaochuxian.SetPosition(xunhuan + 1, zuobiaolist[xunhuan]);
                        }
                        xunhuan = 2;

                        float julicha2_2 = Vector2.Distance(zuobiaolist[xunhuan], xiaochuxian.GetPosition(xunhuan));
                        if (julicha2_2 > 0.2)
                        {
                            huaxian();
                        }
                        else
                        {
                            jiluzuobiao2_1 = false;
                            xiaochu();
                        }
                    }

                    break;
                case 3:
                    xunhuan = 1;
                    float julicha3_1 = Vector2.Distance(zuobiaolist[xunhuan], xiaochuxian.GetPosition(xunhuan));

                    if (julicha3_1 > 0.2)
                    {
                        huaxian();
                    }
                    else if (julicha3_1 <= 0.2)
                    {
                        if (!jiluzuobiao3_1)
                        {
                            jiluzuobiao3_1 = true;
                            xiaochuxian.positionCount = 3;
                            xiaochuxian.SetPosition(xunhuan, zuobiaolist[xunhuan]);
                            xiaochuxian.SetPosition(xunhuan + 1, zuobiaolist[xunhuan]);
                        }
                        xunhuan = 2;

                        float julicha3_2 = Vector2.Distance(zuobiaolist[xunhuan], xiaochuxian.GetPosition(xunhuan));
                        if (julicha3_2 > 0.2)
                        {
                            huaxian();
                        }
                        else if(julicha3_2 <0.2)
                        {
                            if (!jiluzuobiao3_2)
                            {
                                jiluzuobiao3_2 = true;
                                xiaochuxian.positionCount = 4;
                                xiaochuxian.SetPosition(xunhuan, zuobiaolist[xunhuan]);
                                xiaochuxian.SetPosition(xunhuan + 1, zuobiaolist[xunhuan]);
                            }
                            xunhuan = 3;

                            float julicha3_3 = Vector2.Distance(zuobiaolist[xunhuan], xiaochuxian.GetPosition(xunhuan));
                            if (julicha3_3 > 0.2)
                            {
                                huaxian();
                            }
                            else
                            {
                                jiluzuobiao3_1 = false;
                                jiluzuobiao3_2 = false;
                                xiaochu();
                            }
                        }
                    }

                    break;
            }
        }
    }

    int xunhuan;

    void huaxian()
    {
        jishiqi += Time.deltaTime * .5f;
        if (zuobiaolist[xunhuan].x != xiaochuxian.GetPosition(xunhuan).x)
        {
            if (zuobiaolist[xunhuan].x > xiaochuxian.GetPosition(xunhuan).x)
            {
                xiaochuxian.SetPosition(xunhuan,
                    new Vector2(xiaochuxian.GetPosition(xunhuan).x + jishiqi,
                    zuobiaolist[xunhuan].y));
            }
            else
            {
                xiaochuxian.SetPosition(xunhuan,
                        new Vector2(xiaochuxian.GetPosition(xunhuan).x - jishiqi,
                        zuobiaolist[xunhuan].y));
            }
        }
        else if (zuobiaolist[xunhuan].y != xiaochuxian.GetPosition(xunhuan).y)
        {
            if (zuobiaolist[xunhuan].y > xiaochuxian.GetPosition(xunhuan).y)
            {
                xiaochuxian.SetPosition(xunhuan,
                    new Vector2(zuobiaolist[xunhuan].x,
                    xiaochuxian.GetPosition(xunhuan).y + jishiqi));
            }
            else
            {
                xiaochuxian.SetPosition(xunhuan,
                    new Vector2(zuobiaolist[xunhuan].x,
                     xiaochuxian.GetPosition(xunhuan).y - jishiqi));
            }
        }
    }
    void xiaochu()
    {
        xiaochuxian.SetPosition(xunhuan, zuobiaolist[xunhuan]);
        kexiaochu = false;

        duixiang1.GetComponent<xuanzhongsucai>().yixiaochu = true;
        duixiang2.GetComponent<xuanzhongsucai>().yixiaochu = true;
        duixiang1.localScale = Vector2.zero;
        duixiang2.localScale = Vector2.zero;
        duixiang1 = null;
        duixiang2 = null;
        xiaochuxian.positionCount = 0;
        xunhuan = 0;

        if (fangdajingzhong)
        {
            fangdajingzhong = false;
        }
        panduanguoguan();
    }

    bool guoguan;
    void panduanguoguan()
    {
        Transform[] ziduixiang = mianban.GetComponentsInChildren<Transform>();
        for (int i = 1; i < ziduixiang.Length; i++)
        {
            if (ziduixiang[i].name != "wenben")
            {
                if (ziduixiang[i].name != "kong")
                {
                    if (!ziduixiang[i].GetComponent<xuanzhongsucai>().yixiaochu)
                    {
                        return;
                    }
                }
            }
        }
        guoguan = true;
        shifouguoguan.text = "¹ý¹Ø";
        PlayerPrefs.SetString(SceneManager.GetActiveScene().name, "1");
        FindAnyObjectByType<jishiqi>().jishikaishi = false;
    }
    public void fanhuianniu()
    {
        SceneManager.LoadScene("guanqiaxuanze");
    }
    void sucaixuanzhongfuwei()
    {
        Transform[] ziduixiang = mianban.GetComponentsInChildren<Transform>();
        for (int i = 1; i < ziduixiang.Length; i++)
        {
            if (ziduixiang[i].name != "wenben")
            {
                if (ziduixiang[i].name != "kong")
                {
                    ziduixiang[i].GetComponent<xuanzhongsucai>().xuanzhong = false;
                }
            }
        }
    }

    int panduanbiaoshi; // 1 = zhixian  2 = guaiwan1  3 = guaiwan2
    void panduan()
    {
        panduanbiaoshi = 0;

        if (duixiang1 != duixiang2 && duixiang1.name == duixiang2.name)
        {
            if (duixiang1.position.x == duixiang2.position.x || duixiang1.position.y == duixiang2.position.y)
            {
                zhixianpanduan();
                if (kexiaochu)
                {
                    shuzufuzhi();
                    panduanbiaoshi = 1;
                    goto goto_kexiaochu;
                }
            }
            else
            {

                guaiwan1panduan();
                if (kexiaochu)
                {
                    shuzufuzhi();
                    panduanbiaoshi = 2;

                    goto goto_kexiaochu;
                }
            }

            if (!kexiaochu)
            {

                guaiwan2panduan();
                if (kexiaochu)
                {
                    shuzufuzhi();
                    panduanbiaoshi = 3;

                    goto goto_kexiaochu;
                }
            }
        }
        else
        {
            sucaixuanzhongfuwei();
            duixiang1 = null;
            duixiang2 = null;
        }


    goto_kexiaochu:
        if (kexiaochu)
        {
            //   duixiang1.localScale = Vector2.zero;
            //  duixiang2.localScale = Vector2.zero;
            //    duixiang1 = null;
            //    duixiang2 = null;
            //  kexiaochu = false;
            jishiqi = 0;
        }
        else
        {
            xiaochuxian.positionCount = 0;
            sucaixuanzhongfuwei();
            duixiang1 = null;
            duixiang2 = null;
        }
    }
    void shuzufuzhi()
    {
        zuobiaolist.Clear();
        zuobiao1 = Camera.main.ScreenToWorldPoint(huaxianzuobiao1);
        zuobiao2 = Camera.main.ScreenToWorldPoint(huaxianzuobiao2);
        zuobiao3 = Camera.main.ScreenToWorldPoint(huaxianzuobiao3);
        zuobiao4 = Camera.main.ScreenToWorldPoint(huaxianzuobiao4);
        zuobiaolist.Add(zuobiao1);
        zuobiaolist.Add(zuobiao2);
        zuobiaolist.Add(zuobiao3);
        zuobiaolist.Add(zuobiao4);

        xiaochuxian.positionCount = 2;
        xiaochuxian.SetPosition(0, zuobiaolist[0]);
        xiaochuxian.SetPosition(1, zuobiaolist[0]);
    }
    bool kexiaochu;
    Vector3 huaxianzuobiao1;
    Vector3 huaxianzuobiao2;
    Vector3 huaxianzuobiao3;
    Vector3 huaxianzuobiao4;
    void zhixianpanduan()
    {
        Vector2 fangxiang1 = duixiang2.position - duixiang1.position;
        float juli1 = Vector2.Distance(duixiang1.position, duixiang2.position);
        RaycastHit2D[] duixiangall = Physics2D.RaycastAll(duixiang1.position, fangxiang1, juli1, LayerMask.GetMask("sucai"));
        if (duixiangall.Length == 2)
        {
            kexiaochu = true;
            huaxianzuobiao1 = duixiang1.position;
            huaxianzuobiao2 = duixiang2.position;
        }
    }
    void guaiwan1panduan()
    {
        Vector2 fangxiang = duixiang2.position - duixiang1.position;
        float juli1x = fangxiang.x;
        float juli1y = fangxiang.y;
        if (juli1x < 0)
        {
            juli1x = 0 - juli1x;
        }
        if (juli1y < 0)
        {
            juli1y = 0 - juli1y;
        }

        RaycastHit2D[] guaiwan1heng = Physics2D.RaycastAll(
            duixiang1.position, new Vector2(fangxiang.x, 0), juli1x, LayerMask.GetMask("sucai"));

        if (guaiwan1heng.Length == 1)
        {
            Vector2 zuobiao = duixiang1.position + new Vector3(fangxiang.x, 0);
            RaycastHit2D[] guaiwan2heng = Physics2D.RaycastAll(zuobiao,
                new Vector2(0, fangxiang.y), juli1y, LayerMask.GetMask("sucai"));

            if (guaiwan2heng.Length == 1)
            {
                kexiaochu = true;
                huaxianzuobiao1 = duixiang1.position;
                huaxianzuobiao2 = zuobiao;
                huaxianzuobiao3 = duixiang2.position;
                return;
            }
        }

        float juli2y = fangxiang.y;
        float juli2x = fangxiang.x;

        if (juli2y < 0)
        {
            juli2y = 0 - juli2y;
        }
        if (juli2x < 0)
        {
            juli2x = 0 - juli2x;
        }
        RaycastHit2D[] guaiwan1shu = Physics2D.RaycastAll(
            duixiang1.position, new Vector2(0, fangxiang.y), juli2y, LayerMask.GetMask("sucai"));

        if (guaiwan1shu.Length == 1)
        {
            Vector2 zuobiao = duixiang1.position + new Vector3(0, fangxiang.y);

            RaycastHit2D[] guaiwan2shu = Physics2D.RaycastAll(zuobiao,
                new Vector2(fangxiang.x, 0), juli2x, LayerMask.GetMask("sucai"));
            if (guaiwan2shu.Length == 1)
            {
                kexiaochu = true;
                huaxianzuobiao1 = duixiang1.position;
                huaxianzuobiao2 = zuobiao;
                huaxianzuobiao3 = duixiang2.position;
                return;
            }
        }
    }
    Vector3 qibufangxiang;
    float juli;
    float jixianjuli;
    void guaiwan2panduan()
    {
        qibufangxiang = Vector3.zero;
        int weizhisuoyin = duixiang1.transform.GetSiblingIndex();
        int hangshu = weizhisuoyin / mianban_group.constraintCount + 1; 
        int lieshu = (weizhisuoyin + 1) % mianban_group.constraintCount;
        if (lieshu == 0)
        {
            lieshu = mianban_group.constraintCount;
        }

        for (int i = 0; i < 4; i++)
        {
            switch (i)
            {
                case 0:
                    qibufangxiang = Vector2.up;
                    jixianjuli = (mianban_group.cellSize.y + mianban_group.spacing.y) * hangshu;
                    break;
                case 1:
                    qibufangxiang = Vector2.down;
                    int zonghangshu = mianban.transform.childCount / mianban_group.constraintCount;
                    int yushu = mianban.transform.childCount % mianban_group.constraintCount;
                    if (yushu > 0)
                    {
                        zonghangshu++;
                    }
                    jixianjuli = (mianban_group.cellSize.y + mianban_group.spacing.y) * (zonghangshu + 1);
                    break;
                case 2:
                    qibufangxiang = Vector2.left;
                    jixianjuli = (mianban_group.cellSize.x + mianban_group.spacing.x) * lieshu;
                    break;
                case 3:
                    qibufangxiang = Vector2.right;
                    jixianjuli = (mianban_group.cellSize.x + mianban_group.spacing.x) * 
                        (mianban_group.constraintCount - lieshu + 1);
                    break;

            }

            juli = 0;

            while (juli < jixianjuli)
            {
                juli += mianban_group.cellSize.x + mianban_group.spacing.x;
                RaycastHit2D[] duixiangall = Physics2D.RaycastAll(duixiang1.position, qibufangxiang, juli, LayerMask.GetMask("sucai"));
                if (duixiangall.Length == 1)
                {
                    huaxianzuobiao1 = duixiang1.position;
                    huaxianzuobiao2 = duixiang1.position + qibufangxiang * juli;
                    Vector3 fangxiang = duixiang2.position - huaxianzuobiao2;
                    float juli1x = fangxiang.x;
                    float juli1y = fangxiang.y;
                    if (juli1x < 0)
                    {
                        juli1x = 0 - juli1x;
                    }
                    if (juli1y < 0)
                    {
                        juli1y = 0 - juli1y;
                    }

                    RaycastHit2D[] guaiwan1heng = Physics2D.RaycastAll(
                        huaxianzuobiao2, new Vector2(fangxiang.x, 0), juli1x, LayerMask.GetMask("sucai"));

                    if (guaiwan1heng.Length == 0)
                    {
                        Vector2 zuobiao = huaxianzuobiao2 + new Vector3(fangxiang.x, 0);
                        RaycastHit2D[] guaiwan2heng = Physics2D.RaycastAll(zuobiao,
                            new Vector2(0, fangxiang.y), juli1y, LayerMask.GetMask("sucai"));

                        if (guaiwan2heng.Length == 1)
                        {
                            kexiaochu = true;
                            huaxianzuobiao3 = zuobiao;
                            huaxianzuobiao4 = duixiang2.position;
                            return;
                        }
                    }

                    float juli2y = fangxiang.y;
                    float juli2x = fangxiang.x;

                    if (juli2y < 0)
                    {
                        juli2y = 0 - juli2y;
                    }
                    if (juli2x < 0)
                    {
                        juli2x = 0 - juli2x;
                    }
                    RaycastHit2D[] guaiwan1shu = Physics2D.RaycastAll(
                        huaxianzuobiao2, new Vector2(0, fangxiang.y), juli2y, LayerMask.GetMask("sucai"));

                    if (guaiwan1shu.Length == 0)
                    {
                        Vector2 zuobiao = huaxianzuobiao2 + new Vector3(0, fangxiang.y);

                        RaycastHit2D[] guaiwan2shu = Physics2D.RaycastAll(zuobiao,
                            new Vector2(fangxiang.x, 0), juli2x, LayerMask.GetMask("sucai"));
                        if (guaiwan2shu.Length == 1)
                        {
                            kexiaochu = true;
                            huaxianzuobiao3 = zuobiao;
                            huaxianzuobiao4 = duixiang2.position;
                            return;
                        }
                    }


                }

            }

        }
    }

    bool fangdajingzhong;
    public void fangdajingfangfa()
    {
        if (!youxikaishi || guoguan || shibai)
        {
            return;
        }
        if (!fangdajingzhong)
        {
            daojushuxing jiaoben = GameObject.Find("gongneng/fangdajing").GetComponent<daojushuxing>();
            Text shuliangwenben = GameObject.Find("fangdajing/wenben").GetComponent<Text>();
            if (jiaoben.shiyongcishu > 0)
            {
                List<Transform> duixianglist = new List<Transform>();
                Transform[] ziduixiang = mianban.GetComponentsInChildren<Transform>();
                for (int i = 1; i < ziduixiang.Length; i++)
                {
                    if (ziduixiang[i].name != "wenben")
                    {
                        if (ziduixiang[i].name != "kong")
                        {
                            duixianglist.Add(ziduixiang[i]);
                        }
                    }
                }

                fangdajingzhong = true;
                for (int i = 0; i < duixianglist.Count; i++)
                {
                    if (!duixianglist[i].GetComponent<xuanzhongsucai>().yixiaochu)
                    {
                        for (int j = i + 1; j < duixianglist.Count; j++)
                        {
                            if (!duixianglist[j].GetComponent<xuanzhongsucai>().yixiaochu)
                            {
                                if (duixianglist[i].name == duixianglist[j].name)
                                {
                                    duixiang1 = duixianglist[i];
                                    duixiang2 = duixianglist[j];
                                    panduan();
                                    if (kexiaochu)
                                    {
                                        jiaoben.shiyongcishu -= 1;
                                        shuliangwenben.text = (jiaoben.shiyongcishu).ToString();
                                        return;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
    public void zhadanfangfa()
    {
        if (!youxikaishi || guoguan || shibai)
        {
            return;
        }
        daojushuxing jiaoben = GameObject.Find("gongneng/zhadan").GetComponent<daojushuxing>();
        Text shuliangwenben = GameObject.Find("zhadan/wenben").GetComponent<Text>();
        if (jiaoben.shiyongcishu > 0)
        {
            jiaoben.shiyongcishu -= 1;
            shuliangwenben.text = (jiaoben.shiyongcishu).ToString();

            List<Transform> duixianglist = new List<Transform>();
            Transform[] ziduixiang = mianban.GetComponentsInChildren<Transform>();
            for (int i = 1; i < ziduixiang.Length; i++)
            {
                if (ziduixiang[i].name != "wenben")
                {
                    if (ziduixiang[i].name != "kong")
                    {
                        if (!ziduixiang[i].GetComponent<xuanzhongsucai>().yixiaochu)
                        {
                            duixianglist.Add(ziduixiang[i]);
                        }
                    }
                }
            }

            List<Transform> shaixuanlist = new List<Transform>();
            if (duixiang1 != null)
            {
                for (int i = 0; i < duixianglist.Count; i++)
                {
                    if (duixianglist[i].name == duixiang1.name && duixianglist[i] != duixiang1)
                    {
                        shaixuanlist.Add(duixianglist[i]);
                    }
                }

                int suijishu = Random.Range(0, shaixuanlist.Count);
                duixiang1.localScale = Vector3.zero;
                shaixuanlist[suijishu].localScale = Vector3.zero;
                duixiang1.GetComponent<xuanzhongsucai>().yixiaochu = true;
                shaixuanlist[suijishu].GetComponent<xuanzhongsucai>().yixiaochu = true;
                duixiang1 = null;
                duixiang2 = null;
            }
            else
            {

                int suijishu = Random.Range(0, duixianglist.Count);
                //   shaixuanlist.Clear();
                for (int i = 0; i < duixianglist.Count; i++)
                {
                    if (duixianglist[i].name == duixianglist[suijishu].name)
                    {
                        shaixuanlist.Add(duixianglist[i]);
                    }
                }

                int suijishu1 = Random.Range(0, shaixuanlist.Count);
                int suijishu2 = Random.Range(0, shaixuanlist.Count);

                while (suijishu2 == suijishu1)
                {
                    suijishu2 = Random.Range(0, shaixuanlist.Count);
                }

                shaixuanlist[suijishu1].localScale = Vector3.zero;
                shaixuanlist[suijishu2].localScale = Vector3.zero;
                shaixuanlist[suijishu1].GetComponent<xuanzhongsucai>().yixiaochu = true;
                shaixuanlist[suijishu2].GetComponent<xuanzhongsucai>().yixiaochu = true;
                duixiang1 = null;
                duixiang2 = null;
            }

            panduanguoguan();
        }
    }
    public void daluanfangfa()
    {
        if (!youxikaishi || guoguan || shibai)
        {
            return;
        }
        daojushuxing jiaoben = GameObject.Find("gongneng/daluan").GetComponent<daojushuxing>();
        Text shuliangwenben = GameObject.Find("daluan/wenben").GetComponent<Text>();
        if (jiaoben.shiyongcishu > 0)
        {
            jiaoben.shiyongcishu -= 1;
            shuliangwenben.text = (jiaoben.shiyongcishu).ToString();
            daluanshunxu();
        }
    }
    public void jiashijianfangfa()
    {
        if (!youxikaishi || guoguan || shibai)
        {
            return;
        }
        daojushuxing jiaoben = GameObject.Find("gongneng/jiashijian").GetComponent<daojushuxing>();
        Text shuliangwenben = GameObject.Find("jiashijian/wenben").GetComponent<Text>();
        if (jiaoben.shiyongcishu > 0)
        {
            jiaoben.shiyongcishu -= 1;
            shuliangwenben.text = (jiaoben.shiyongcishu).ToString();
            FindAnyObjectByType<jishiqi>().daojishi += 20;
        }
    }
}
