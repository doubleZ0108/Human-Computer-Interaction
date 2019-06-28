using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Seperate_guzheng : MonoBehaviour
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
            // Define a target position above and behind the target transform
            Vector3 zhengweidis = new Vector3(-30, 0, 0);      //目标位置(就是编辑器上的位置)
            zhengwei.targetPosition = zhengwei.originPosition + zhengweidis;

            Vector3 zhengjiadis = new Vector3(0, -10, 0);      //目标位置(就是编辑器上的位置)
            zhengjia.targetPosition = zhengjia.originPosition + zhengjiadis;

            Vector3 zhengshoudis = new Vector3(30, 0, 0);      //目标位置(就是编辑器上的位置)
            zhengshou.targetPosition = zhengshou.originPosition + zhengshoudis;

            Vector3 bandis = new Vector3(0, 80, 0);      //目标位置(就是编辑器上的位置)
            ban.targetPosition = ban.originPosition + bandis;

            Vector3 qinxiandis = new Vector3(0, 50, 0);      //目标位置(就是编辑器上的位置)
            qinxian.targetPosition = qinxian.originPosition + qinxiandis;

        });
    }
}
