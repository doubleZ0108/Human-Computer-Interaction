using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cohere_pipa : MonoBehaviour
{
    public chanxianController chanxian;
    public mianbanController mianban;
    public qinjingController qinjing;
    public shankouController shankou;
    public zhongxianController zhongxian;
    void Start()
    {
        this.GetComponent<Button>().onClick.AddListener(delegate ()
        {
           
            chanxian.targetPosition = chanxian.originPosition;

            
            mianban.targetPosition = mianban.originPosition;

           
            qinjing.targetPosition = qinjing.originPosition;

            
            shankou.targetPosition = shankou.originPosition;

            
           zhongxian.targetPosition = zhongxian.originPosition;
        });
    }
}