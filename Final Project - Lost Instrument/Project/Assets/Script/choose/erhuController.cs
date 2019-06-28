using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class erhuController : MonoBehaviour
{
    private Vector3[] position = {
        new Vector3(-0.24f, -2.44f, 4.2f),      //前0
        new Vector3(-15.70f, -4.40f, 16.30f),      //左1
        new Vector3(-0.49f,-0.78f,24.89f),        //后2
        new Vector3(11.4f,-3.31f,13.57f),       //右3
    };
    private float smoothTime = 0.3F;
    private Vector3 velocity = Vector3.zero;

    private int now = 2;

    public Renderer rend;
    void Start()
    {
        rend = GetComponent<Renderer>();
        //rend.enabled = false;
    }

    void Update()
    {
        // Smoothly move the camera towards that target position
        transform.position = new Vector3(Mathf.SmoothDamp(transform.position.x, position[(Controller.cnt + 2) % 4].x, ref velocity.x, smoothTime),
            Mathf.SmoothDamp(transform.position.y, position[(Controller.cnt + 2) % 4].y, ref velocity.y, smoothTime),
            Mathf.SmoothDamp(transform.position.z, position[(Controller.cnt + 2) % 4].z, ref velocity.z, smoothTime));

        now = (Controller.cnt + 2) % 4;
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
