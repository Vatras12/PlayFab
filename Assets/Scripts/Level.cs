using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


/// <summary>
///     In this script scenes that are not game levels load by thier names (titles), and scenes which are levels
///     load by the scene index. Such approarch requires to place game levels from 1 to N in unity build settings, and place
///     non-level scene after all the levels, exept the main menu scene, main menu scene must be the very first scene
/// </summary>
/// 

public class Level : MonoBehaviour
{

    // static variables for storing next level's index to play
    public static string NEXT_LEVEL_KEY = "nextLevelToPlay"; 
    public static int LEVEL_TO_START = 1;

    // static variables for storing last played level index
    public static string LAST_LEVEL_KEY = "lastPlayedLevel";
    public static int LEVEL_TO_PLAY = 1;

    // statuc varuables for storing game over flag
    public static string GAME_COMPLETE_KEY = "gameComplete";
    // 0 means game is not complete, 1 - game complete
    public static int GAME_INCOMPLETE = 0; 
    public static int GAME_COMPLETE = 1; 

    [SerializeField] Button[] levelButtons; // arrays of buttons references that allow to load selected level
    [SerializeField] int totalSceneNumber = 30; // variable that represents total level number

    // Start is called before the first frame update
    void Start()
    {
        EnableLevelLoadButtons();
    }

    private void EnableLevelLoadButtons()
    {
        // if level load buttons array was not assign in editor abort running this fuction
        if (levelButtons.Length == 0)
        {
            return;
        }
        // getting the number of last complete level
        int levelReached = PlayerPrefs.GetInt(NEXT_LEVEL_KEY, LEVEL_TO_START);
        // making buttons for unreached levels unactive
        for (int i = 0; i < levelButtons.Length; i++)
        {
            if (i > levelReached - 1)
            {
                levelButtons[i].interactable = false;
            }
        }
    }

    public int GetTotalSceneNumber() { return totalSceneNumber; }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    // function that is called when we successfully finish the last level in the game
    public void SetGameOverKey() { PlayerPrefs.SetInt(GAME_COMPLETE_KEY, GAME_COMPLETE); }

    public void LoadLastPassedScene()
    {
        // check if the game is complete and load level selection scene if it is so
        // only this piece of code will be executed
        if (PlayerPrefs.GetInt(GAME_COMPLETE_KEY, GAME_INCOMPLETE) == 1)
        {
            SceneManager.LoadScene("LevelSelectionScene");
            return;
        }
        // otherwise getting the next scene to load index
        int sceneToLoadIndex = PlayerPrefs.GetInt(NEXT_LEVEL_KEY, LEVEL_TO_START);
        //Debug.Log("sceneToLoadIndex = " + sceneToLoadIndex);
        // if index equals totalSceneNumber value plus one (the last level has be loaded), loading 
        // scene with index sceneToLoadIndex - 1
        if (sceneToLoadIndex == totalSceneNumber + 1)
        {
            SceneManager.LoadScene(sceneToLoadIndex - 1);
        }
        // otherwise loading scene with index sceneToLoadIndex
        else
        {
            SceneManager.LoadScene(sceneToLoadIndex);
        }
    }

    public void LoadNextScene()
    {
        // check if the game is complete and load level selection scene if it is so
        // only this piece of code will be executed
        if (PlayerPrefs.GetInt(GAME_COMPLETE_KEY, GAME_INCOMPLETE) == 1)
        {
            SceneManager.LoadScene("LevelSelectionScene");
            return;
        }
        // otherwise getting the next scene to load index and loading it
        int nextLevelIndex = PlayerPrefs.GetInt(NEXT_LEVEL_KEY, LEVEL_TO_START);
        SceneManager.LoadScene(nextLevelIndex);
    }

    public void ReloadScene()
    {
        // getting the last played scene index (it is written when GameOver() function execute
        int levelIndex = PlayerPrefs.GetInt(LAST_LEVEL_KEY, LEVEL_TO_PLAY);
        SceneManager.LoadScene(levelIndex);
    }

    public void LoadLevelSelectorScene()
    {
        SceneManager.LoadScene("LevelSelectionScene");
    }

    public void LoadGameOverScene()
    {
        SceneManager.LoadScene("LevelFailedScene");
    }

    public void LoadLevelCompleteScene()
    {
        SceneManager.LoadScene("LevelCompleteScene");
    }

    public void Quit()
    {
        Application.Quit();
    }

    // loading the scene by pointing the level to load
    public void LoadScene(int levelIndex)
    {
        SceneManager.LoadScene(levelIndex);
    }
}
