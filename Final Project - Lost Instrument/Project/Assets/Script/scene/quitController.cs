using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class quitController : MonoBehaviour
{
    void Start()
    {
        this.GetComponent<Button>().onClick.AddListener(delegate ()
        {
            Application.Quit();
        });
    }

    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
