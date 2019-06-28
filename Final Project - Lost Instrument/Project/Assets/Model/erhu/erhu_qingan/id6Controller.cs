using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class id6Controller : MonoBehaviour
{
    public Quaternion targetRotation;
    public Vector3 rotateVector;

    // Start is called before the first frame update
    void Start()
    {
        targetRotation = transform.rotation;
        rotateVector = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, Time.deltaTime * 50);
    }
}
