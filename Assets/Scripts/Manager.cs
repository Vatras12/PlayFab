using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{

    [SerializeField] Rotator rotator; // reference to rotator object
    [SerializeField] PinSpawner pinSpawner; // reference to pinSpawner object
    [SerializeField] CameraAnimator cameraAnimator; // reference to cameraAnimator component that allows to controll camera animation
    [SerializeField] int numberOfPins; // number of pins to complete level, set it via editor for each level seperately
    private bool gameEnded = false; // variable that prevent calling GameOver() method more than one time
    private int currentNumberOfPins = 0; // number of pins that are on the rotator
 
    public int GetTotalNumberOfPins() { return numberOfPins; }

    public int GetCurrentNumberOfPins() { return currentNumberOfPins; }

    public void AddPin() { currentNumberOfPins++; }

    public void GameOver(int sceneIndex)
    {
        // if the game has ended no action will be done
        if (gameEnded)
        {
            return;
        }
        Debug.Log("ENDGAME");
        PlayerPrefs.SetInt(Level.LAST_LEVEL_KEY, sceneIndex); // setting last played level to PlayerPrefs
        gameEnded = true;
        DisableGameElements();
        cameraAnimator.SetGameOverTrigger(); // activatin game over animatin by setting up the trigger
    }

    public void LevelComplete(int sceneIndex)
    {
        // if the game has ended no action will be done
        if (gameEnded)
        {
            return;
        }
        Debug.Log("LEVEL COMPLETE");
        gameEnded = true;
        DisableGameElements();
        int nextLevelIndex = PlayerPrefs.GetInt(Level.NEXT_LEVEL_KEY, Level.LEVEL_TO_START); // getting last complete scene
        //Debug.Log("nextLevelIndex = " + nextLevelIndex);
        // if sceneIndex is greater than nextLevelIndex (this means that we complete this level for the first time)
        if (sceneIndex >= nextLevelIndex)
        {
            // setting this level index to PlayerPrefs
            //Debug.Log(sceneIndex);
            PlayerPrefs.SetInt(Level.NEXT_LEVEL_KEY, sceneIndex + 1);
            //PlayerPrefs.SetInt(Level.LAST_LEVEL_KEY, sceneIndex);
        }
        cameraAnimator.SetLevelCompleteTrigger(); // activatin level complete animatin by setting up the trigger
    }

    private void DisableGameElements()
    {
        rotator.enabled = false; // disable the rotator component
        pinSpawner.enabled = false; // disable the pinSpawner component
    }
}
