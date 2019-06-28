using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class id14Rotate : MonoBehaviour
{
    public id14Controller2 id14;
    public Vector3 dis = new Vector3(0, 90, 0);
    void Start()
    {
        this.GetComponent<Button>().onClick.AddListener(delegate ()
        {
            id14.rotateVector += dis;
            id14.targetRotation = Quaternion.Euler(id14.rotateVector);


        });
    }
}
