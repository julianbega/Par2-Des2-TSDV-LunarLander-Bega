using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerReference : MonoBehaviour
{
    private GameManager referenceManager;
    private void Awake()
    {
        referenceManager = null;
    }
    void Start()
    {
        referenceManager = FindObjectOfType<GameManager>();
    }
    void LateStart()
    {
        if (referenceManager == null)
            referenceManager = FindObjectOfType<GameManager>();
    }

    public void PauseGame()
    {
        referenceManager.Pause();
    }
}
