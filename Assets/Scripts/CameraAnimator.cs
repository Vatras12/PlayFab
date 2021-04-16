using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAnimator : MonoBehaviour
{

    [SerializeField] Animator animator; // reference to animator component that is placed on main camera
    [SerializeField] Level level; // reference to level object

    public void SetGameOverTrigger()
    {
        animator.SetTrigger("GameOver");
    }

    public void SetLevelCompleteTrigger()
    {
        animator.SetTrigger("LevelComplete");
    }

    public void LoadLevelCompleteScene()
    {
        // getting next scene to load index
        int nextSceneIndex = PlayerPrefs.GetInt(Level.NEXT_LEVEL_KEY, Level.LEVEL_TO_START);
        //Debug.Log("nextSceneIndex = " + nextSceneIndex);
        // if the next scene index equals totalSceneNumber (it means that last level was complete
        if (nextSceneIndex == level.GetTotalSceneNumber() + 1)
        {
            // setting game complete flag to PlayerPrefs
            PlayerPrefs.SetInt(Level.GAME_COMPLETE_KEY, Level.GAME_COMPLETE);
            level.LoadLevelSelectorScene(); // loading level selector scene
        }
        else
        {
            level.LoadLevelCompleteScene(); // loading level complete scene
        }
    }

    public void LoadGameOverScene()
    {
        level.LoadGameOverScene();
    }
}

