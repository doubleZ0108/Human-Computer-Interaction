using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class rotateController : MonoBehaviour
{
    public objRotateController obj;
    private Quaternion compass_targetRotation;

    void Start()
    {
        compass_targetRotation = Quaternion.Euler(new Vector3(91.5f, 88.5f, -82.5f)) * Quaternion.identity;
    }

    void Update()
    {
        compass_targetRotation = Quaternion.Euler(new Vector3(91.5f, 88.5f, -82.5f + obj.targetRotation.y * 180.0f)) * Quaternion.identity;
        
        transform.rotation = Quaternion.Slerp(transform.rotation, compass_targetRotation, Time.deltaTime * 3);//利用Slerp插值让物体进行旋转  2是旋转速度 越大旋转越快
                
    }


}
