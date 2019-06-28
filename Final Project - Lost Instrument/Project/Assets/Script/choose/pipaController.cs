using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pipaController : MonoBehaviour
{
    private Vector3[] position = {
        new Vector3(-10.79f, -9.77f, -87.76f),      //前0
        new Vector3(-20.79f, -9.77f, -80.25f),      //左1
        new Vector3(-9.56f,-8.72f,-64.49f),        //后2
        new Vector3(0.48f, -10.74f, -78.6f),       //右3
    };
    private float smoothTime = 0.3F;
    private Vector3 velocity = Vector3.zero;

    private int now = 3;

    void Update()
    {
        // Smoothly move the camera towards that target position
        transform.position = new Vector3(Mathf.SmoothDamp(transform.position.x, position[(Controller.cnt + 3) % 4].x, ref velocity.x, smoothTime),
            Mathf.SmoothDamp(transform.position.y, position[(Controller.cnt + 3) % 4].y, ref velocity.y, smoothTime),
            Mathf.SmoothDamp(transform.position.z, position[(Controller.cnt + 3) % 4].z, ref velocity.z, smoothTime));

        now = (Controller.cnt + 3) % 4;
    }

    void OnMouseDown()
    {
        Debug.Log("click....");
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
