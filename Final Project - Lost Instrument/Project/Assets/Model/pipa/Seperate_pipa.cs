using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Seperate_pipa : MonoBehaviour
{
    public zhongxianController zhongxian;
    public chanxianController chanxian;
    public qinjingController qinjing;
    public shankouController shankou;
    public mianbanController mianban;
    void Start()
    {
        this.GetComponent<Button>().onClick.AddListener(delegate ()
        {
            // Define a target position above and behind the target transform
            Vector3 zhongxiandis = new Vector3(-50, 0, 0);      //目标位置(就是编辑器上的位置)
            zhongxian.targetPosition = zhongxian.originPosition + zhongxiandis;

            Vector3 chanxiandis = new Vector3(50, 0, 0);      //目标位置(就是编辑器上的位置)
            chanxian.targetPosition = chanxian.originPosition + chanxiandis;

            Vector3 qinjingdis = new Vector3(0, 80, 0);      //目标位置(就是编辑器上的位置)
            qinjing.targetPosition = qinjing.originPosition + qinjingdis;

            Vector3 shankoudis = new Vector3(0, 50, 0);      //目标位置(就是编辑器上的位置)
            shankou.targetPosition = shankou.originPosition + shankoudis;

            Vector3 mianbandis = new Vector3(0, -50, 0);      //目标位置(就是编辑器上的位置)
            mianban.targetPosition = mianban.originPosition + mianbandis;

        });
    }
}
