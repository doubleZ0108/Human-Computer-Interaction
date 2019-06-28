using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cohere_erhu : MonoBehaviour
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
           
            id4.targetPosition = id4.originPosition;

            
            id8.targetPosition = id8.originPosition;

           
            id10.targetPosition = id10.originPosition;

            
            id14.targetPosition = id14.originPosition;

            
            id16.targetPosition = id16.originPosition;
        });
    }
}