using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{

    private int pinCount; // number of pins to show
    [SerializeField] TextMeshProUGUI text; // reference to the textMeshPro`s text component

    // Start is called before the first frame update
    void Start()
    {
        pinCount = FindObjectOfType<Manager>().GetTotalNumberOfPins(); // getting total number of pins from manager
    }

    // Update is called once per frame
    void Update()
    {
        text.text = pinCount.ToString(); // updating score on the screen
    }

    public void ChangeNumberOfPins() { pinCount--; } // decreasing remaining number of pins on each pin hit
}
