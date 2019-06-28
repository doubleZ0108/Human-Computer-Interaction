using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objRotateController : MonoBehaviour
{
    public Quaternion targetRotation;
    private Quaternion originRotation;
    private float RotateAngle = 30;
    public float limit = 0.9f;

    void Start()
    {
        originRotation = Quaternion.Euler(transform.eulerAngles) * Quaternion.identity;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (transform.rotation.y < limit)
            {
                Rotate();
            }
        }
        if (Input.GetMouseButton(0))
        {
            if (transform.rotation.y < limit)
            {
                Rotate();
            }
        }
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 3);//利用Slerp插值让物体进行旋转  2是旋转速度 越大旋转越快
    }

    public void Rotate()
    {
        float x = transform.eulerAngles.x;
        float y = transform.eulerAngles.y + RotateAngle;
        float z = transform.eulerAngles.z;
        targetRotation = Quaternion.Euler(new Vector3(x, y, z)) * Quaternion.identity;  //给旋转目标值赋值，由于只有Y轴动，所以目标值应是  (旋转角(RotateAngle)*需要旋转的个数(count)+origionY(物体初始Y轴旋转角))*Quarternion.identity
    }
}
