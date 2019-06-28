using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class id6Rotate : MonoBehaviour
{
    public id6Controller id6;
    public Vector3 dis = new Vector3(0, 90, 0);
    void Start()
    {
        this.GetComponent<Button>().onClick.AddListener(delegate ()
        {
            id6.rotateVector += dis;
            id6.targetRotation = Quaternion.Euler(id6.rotateVector);


        });
    }
}
