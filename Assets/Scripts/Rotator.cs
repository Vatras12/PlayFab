using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{

    [SerializeField] private float speed = 100f; // rotation speed, use negative value to rotate backwards

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0f, 0f, speed * Time.deltaTime); // make the circle to rotate 
    }
}
