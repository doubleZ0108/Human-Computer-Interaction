using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class cameraForward : MonoBehaviour
{
    public CameraMove camera;
    public int distance;
    public int offsetX = 0;
    public int offsetY = 0;
    public GameObject obj;

    void Start()
    {
        this.GetComponent<Button>().onClick.AddListener(delegate ()
        {
            camera.targetPosition.x = obj.transform.position.x + offsetX;
            camera.targetPosition.y = obj.transform.position.y + offsetY;
            camera.targetPosition.z = obj.transform.position.z - distance;
        });
    }
}
