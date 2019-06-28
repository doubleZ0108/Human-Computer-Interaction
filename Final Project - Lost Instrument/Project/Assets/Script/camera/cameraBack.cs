using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class cameraBack : MonoBehaviour
{
    public CameraMove camera;
    private Vector3 originPosition;


    void Start()
    {
        originPosition = camera.transform.position;

        this.GetComponent<Button>().onClick.AddListener(delegate ()
        {
            camera.targetPosition = originPosition;
        });
    }
}

