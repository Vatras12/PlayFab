using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject textMeshProObject; // reference to textMeshPro object to show next loaded level
    [SerializeField] Level level; // reference to Level object

    // Start is called before the first frame update
    void Start()
    {
        int passedLevelIndex = PlayerPrefs.GetInt(Level.NEXT_LEVEL_KEY, Level.LEVEL_TO_START); // getting last passed level index
        int lastLevelIndex = level.GetTotalSceneNumber(); // getting the very last scene index 
        // setting up the text
        textMeshProObject.GetComponent<TextMeshProUGUI>().text = "Play level " + (passedLevelIndex).ToString();

    }
}
