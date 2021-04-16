using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pin : MonoBehaviour
{

    [SerializeField] private float speed = 20f; // pin move speed
    [SerializeField] Rigidbody2D rigidbody; // reference to RigidBody2D component
    private bool isPinned = false; // bool variable that tell if pin reach the rotator or not

    // Update is called once per frame
    void FixedUpdate()
    {
        // if pin does not reach the rotator
        if (!isPinned)
        {
            rigidbody.MovePosition(rigidbody.position + Vector2.up * speed * Time.fixedDeltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collisionObj)
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex; // getting the active scene (level) index
        // if pin collides with the object with tag "Pin" (the other pin), we provides game over functionality
        if (collisionObj.tag == "Pin")
        {
            FindObjectOfType<Manager>().GameOver(sceneIndex);
        }
        // if pin collides with the object with tag "Rotator" (the Rotator)
        else if (collisionObj.tag == "Rotator")
        {
            isPinned = true; // stop pin's movement
            transform.SetParent(collisionObj.transform); // make pin part of the rotator
            FindObjectOfType<Score>().ChangeNumberOfPins(); // when pin hits the rotator, decrease number of pins on the score
            Manager manager = FindObjectOfType<Manager>(); // getting manager object from the scene
            manager.AddPin(); // increasing number of pinned pins in manager
            // in the number of pinned pins is equal to the total number of pins for this level
            if (manager.GetTotalNumberOfPins() == manager.GetCurrentNumberOfPins())
            {
                manager.LevelComplete(sceneIndex); // manager`s function that allows to fix level completion
            }
        }
    }

}
