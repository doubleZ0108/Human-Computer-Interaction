using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zhongxianController : MonoBehaviour
{
    public Transform target;
    public float smoothTime = 0.3F;
    private Vector3 velocity = Vector3.zero;
    public Vector3 targetPosition;
    public Vector3 originPosition;
    void Start()
    {
        targetPosition = transform.position;
        originPosition = transform.position;
    }
    void Update()
    {

        // Smoothly move the camera towards that target position
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}
