using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Cohere_guzheng : MonoBehaviour
{
    public zhengweiController zhengwei;
    public zhengjiaController zhengjia;
    public zhengshouController zhengshou;
    public banController ban;
    public qinxianController qinxian;
    void Start()
    {
        this.GetComponent<Button>().onClick.AddListener(delegate ()
        {

            zhengwei.targetPosition = zhengwei.originPosition;


            zhengjia.targetPosition = zhengjia.originPosition;


            zhengshou.targetPosition = zhengshou.originPosition;


            ban.targetPosition = ban.originPosition;


            qinxian.targetPosition = qinxian.originPosition;
        });
    }
}
