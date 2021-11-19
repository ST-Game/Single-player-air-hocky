using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonSceneLoader : MonoBehaviour
{
    [SerializeField] private string nextScene;

    private void Start()
    {
        nextScene = SceneManager.GetActiveScene().name;
    }

    public void loadScene()
    {
        SceneManager.LoadScene(nextScene);
    }
}
