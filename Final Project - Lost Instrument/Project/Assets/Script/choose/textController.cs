using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class textController : MonoBehaviour
{
    private Vector3[] position = {
        new Vector3(1.37f, -1.38f, -1.71f),      //前
        new Vector3(-4.23f, -2.09f, 2.78f),      //左
        new Vector3(0.95f, -0.59f, 11.59f),        //后
        new Vector3(9.42f, -3.29f, 7.24f),       //右
    };
    private float smoothTime = 0.3F;
    private Vector3 velocity = Vector3.zero;

    private int now = 0;

    public Renderer rend;
    void Start()
    {
        rend = GetComponent<Renderer>();
        //rend.enabled = false;
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
