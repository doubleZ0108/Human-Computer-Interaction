using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class resetController : MonoBehaviour
{
    public objRotateController obj;
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Button>().onClick.AddListener(delegate ()
        {
            obj.targetRotation = Quaternion.Euler(new Vector3(0, 0, 0)) * Quaternion.identity;
        });
    }

}
