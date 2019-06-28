using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


//绑定LevelChangeFoeModel之后绑定相应model的ClckParts的script

public class LevelChangeForModels : MonoBehaviour
{
    public Animator animator;
    public clickParts clickParts;

    private int levelToLoad;

    private void Start()
    {
        levelToLoad = clickParts.levelToMove;
    }

    // Update is called once per frame
    void Update()
    {
        if (clickParts.startToChange)
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
