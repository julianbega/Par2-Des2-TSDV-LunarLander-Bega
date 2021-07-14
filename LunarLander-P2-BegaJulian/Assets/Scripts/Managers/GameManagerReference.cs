using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerReference : MonoBehaviour
{
    public GameManager referenceManager;
    public CustomSceneManager referenceSceneManager;
    private void Awake()
    {
        referenceManager = null;
        referenceSceneManager = null;
    }
    void Start()
    {
        referenceManager = FindObjectOfType<GameManager>();
        referenceSceneManager = FindObjectOfType<CustomSceneManager>();
    }
    void LateStart()
    {
        if (referenceManager == null)
        {
            referenceManager = FindObjectOfType<GameManager>();
        }
        if (referenceSceneManager == null)
        {
            referenceSceneManager = FindObjectOfType<CustomSceneManager>();
        }

    }
    void Update()
    {
        if (referenceManager == null)
        {
            referenceManager = FindObjectOfType<GameManager>();
        }
        if (referenceSceneManager == null)
        {
            referenceSceneManager = FindObjectOfType<CustomSceneManager>();
        }

    }

    public void PauseGame()
    {
        referenceManager.Pause();
    }

    public void GoToMenu()
    {
        referenceSceneManager.ChangeScene("Menu");
    }
    public void GoToGame()
    {
        referenceSceneManager.ChangeScene("Game");
    }
    public void GoToCredits()
    {
        referenceSceneManager.ChangeScene("Credits");
    }
    public void ExitGame()
    {
        referenceSceneManager.OnClickQuit();
    }

    public void newLvl()
    {
        referenceManager.StartNewLvl();
    }
    public void newGame()
    {
        referenceManager.GoToGame();
    }
    public void ReadPlayersName(string name)
    {
        referenceManager.ReadPlayersName(name);
    }
}



