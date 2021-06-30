﻿using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneManager : MonoBehaviour
{
    public static SceneManager instanceSceneManager;

    public static SceneManager Instance { get { return instanceSceneManager; } }

    private void Awake()
    {
        if (instanceSceneManager != null && instanceSceneManager != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instanceSceneManager = this;
        }
    }

    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    private void OnDisable()
    {
    }

    public void ChangeScene(string scene)
    {
        Debug.Log("Cambia de escena a" + scene);
        UnityEngine.SceneManagement.SceneManager.LoadScene(scene);
    }

    public void OnClickQuit()
    {
        Application.Quit();
    }
}