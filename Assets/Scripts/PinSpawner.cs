using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinSpawner : MonoBehaviour
{

    [SerializeField] GameObject pinPrefab; // reference to pin object (prefab)

    // Update is called once per frame
    void Update()
    {
        // on mouse click or screen touch spawn pins
        if (Input.GetMouseButtonDown(0))
        {
            SpawnPin();
        }
    }

    private void SpawnPin()
    {
        Instantiate(pinPrefab, transform.position, Quaternion.identity);
    }
}
