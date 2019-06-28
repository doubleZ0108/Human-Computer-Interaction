using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backController : MonoBehaviour
{
    private Vector3[] position = {
        new Vector3(-0.01f, -0.95f, -0.99f),      //前
        new Vector3(-5.09f, -0.2f, 0.03f),      //左
        new Vector3(-0.25f,1.0f,3.33f),        //后
        new Vector3(8.45f, -1.6f, 5.32f),       //右
    };
    private float smoothTime = 0.3F;
    private Vector3 velocity = Vector3.zero;

    private int now = 0;

    public Renderer rend;
    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = false;
    }

    void Update()
    {
        // Smoothly move the camera towards that target position
        transform.position = new Vector3(Mathf.SmoothDamp(transform.position.x, position[Controller.cnt % 4].x, ref velocity.x, smoothTime),
            Mathf.SmoothDamp(transform.position.y, position[Controller.cnt % 4].y, ref velocity.y, smoothTime),
            Mathf.SmoothDamp(transform.position.z, position[Controller.cnt % 4].z, ref velocity.z, smoothTime));


        now = (Controller.cnt % 4);
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
