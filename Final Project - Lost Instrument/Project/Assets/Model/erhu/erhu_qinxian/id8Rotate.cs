using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class id8Rotate : MonoBehaviour
{
    public id8Controller2 id8;
    public Vector3 dis = new Vector3(0, 90, 0);
    void Start()
    {
        this.GetComponent<Button>().onClick.AddListener(delegate ()
        {
            id8.rotateVector += dis;
            id8.targetRotation = Quaternion.Euler(id8.rotateVector);


        });
    }
}
