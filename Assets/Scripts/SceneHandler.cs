using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class SceneHandler : MonoBehaviour
{
    [SerializeField] private string triggeringTag;
    [Tooltip("Enter a two digit number like 00, 05, 13")]
    [SerializeField] private string nextLevelNumber;
    private string nextScene;

    private void Start()
    {
        nextScene = "Level " + nextLevelNumber;
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == triggeringTag)
        {
            Debug.Log(nextScene);
            SceneManager.LoadScene(nextScene);
        }
    }
}
