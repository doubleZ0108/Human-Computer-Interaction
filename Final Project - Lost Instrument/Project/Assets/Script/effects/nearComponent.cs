using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nearComponent : MonoBehaviour
{
    public CameraMove camera;

    // Update is called once per frame
    void OnMouseDown()
    {
     
        camera.targetPosition.x = transform.position.x;
        camera.targetPosition.y = transform.position.y+30;
        camera.targetPosition.z = transform.position.z-200;
    }
}
