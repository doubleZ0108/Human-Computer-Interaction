using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelChange : MonoBehaviour
{
    public Animator animator;
    public startGame startGame;

    public int levelToLoad;
    // Update is called once per frame
    void Update()
    {
        if(startGame.bStart)
        {
            fadeToLevel(levelToLoad); 
        }
    }

    public void fadeToLevel(int levelIndex) 
    {
        animator.SetTrigger("bFadeOut");
    }

    public void fadeOutComplete()
    {
        SceneManager.LoadScene(levelToLoad);
    }

}
