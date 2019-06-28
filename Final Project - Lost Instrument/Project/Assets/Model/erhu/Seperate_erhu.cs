using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Seperate_erhu : MonoBehaviour
{
    public id4Controller id4;
    public id8Controller id8;
    public id10Controller id10;
    public id14Controller id14;
    public id16Controller id16;
    void Start()
    {
        this.GetComponent<Button>().onClick.AddListener(delegate ()
        {
            // Define a target position above and behind the target transform
            Vector3 id4dis = new Vector3(100, 0, 0);      //目标位置(就是编辑器上的位置)
            id4.targetPosition = id4.originPosition + id4dis;

            Vector3 id8dis = new Vector3(50, 0, 0);      //目标位置(就是编辑器上的位置)
            id8.targetPosition = id8.originPosition + id8dis;

            Vector3 id10dis = new Vector3(-50, 0, 0);      //目标位置(就是编辑器上的位置)
            id10.targetPosition = id10.originPosition + id10dis;

            Vector3 id14dis = new Vector3(0, -10, 0);      //目标位置(就是编辑器上的位置)
            id14.targetPosition = id14.originPosition + id14dis;

            Vector3 id16dis = new Vector3(0, -20, 0);      //目标位置(就是编辑器上的位置)
            id16.targetPosition = id16.originPosition + id16dis;

        });
    }
}
