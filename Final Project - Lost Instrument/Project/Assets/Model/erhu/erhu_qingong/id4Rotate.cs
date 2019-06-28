using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class id4Rotate : MonoBehaviour
{
    public id4Controller2 id4;
    public Vector3 dis = new Vector3(0, 90, 0);
    void Start()
    {
        this.GetComponent<Button>().onClick.AddListener(delegate ()
        {
            id4.rotateVector += dis;
            id4.targetRotation = Quaternion.Euler(id4.rotateVector);


        });
    }
}
