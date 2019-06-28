using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MusicController : MonoBehaviour
{
    public Button PlayBtn;
    public Button StopBtn;
    // Start is called before the first frame update
    void Start()
    {
        AudioSource As = gameObject.GetComponent<AudioSource>();

        PlayBtn.onClick.AddListener(delegate ()
        {
            As.Play();
        });

        StopBtn.onClick.AddListener(delegate ()
        {
            As.Stop();
        });
    }


}
