using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class guzhengController : MonoBehaviour
{
    private Vector3[] position = {
        new Vector3(7.3f, -6.18f, 1.65f),      //前
        new Vector3(-3.85f, -8.41f, 11.78f),      //左
        new Vector3(7.36f, -4.51f, 16.01f),       //后
        new Vector3(21.61f, -9.24f, 13.61f),       //右
    };
    private float smoothTime = 0.3F;
    private Vector3 velocity = Vector3.zero;

    private int now = 1;

    void Update()
    {
        // Smoothly move the camera towards that target position
        transform.position = new Vector3(Mathf.SmoothDamp(transform.position.x, position[(Controller.cnt + 1) % 4].x, ref velocity.x, smoothTime),
            Mathf.SmoothDamp(transform.position.y, position[(Controller.cnt + 1) % 4].y, ref velocity.y, smoothTime),
            Mathf.SmoothDamp(transform.position.z, position[(Controller.cnt + 1) % 4].z, ref velocity.z, smoothTime));

        now = (Controller.cnt + 1) % 4;
    }

    void OnMouseDown()
    {
        if (now == 1) { Controller.cnt = (4 + (Controller.cnt - 1)) % 4; }
        else if (now == 2)
        {
            Controller.cnt = (Controller.cnt + 1) % 4;
            Invoke("growth", 0.3f);
        }
        else if (now == 3) { Controller.cnt = (Controller.cnt + 1) % 4; }
    }

    void growth()
    {
        Controller.cnt = (Controller.cnt + 1) % 4;
    }
}
