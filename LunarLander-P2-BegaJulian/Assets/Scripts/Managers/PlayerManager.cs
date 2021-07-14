﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerManager : MonoBehaviour
{
    public float degreesExcededToConsiderACrash;
    public float speedExcededToConsiderACrash;
    const float baseMapAltitude = 5f;
    public float fuel;
    public float score;
    public float rotationSpeed;
    public float propultionSpeed;
    public float gravity;
    public int lvl;
    public float defaultPointsPerLanding;
    public bool victory;
    public bool playerIsDeath;
    private float scoreThisLevel;

    private int timerMin;
    private float timerSec;


    private float horizontalSpeed;
    private float verticalSpeed;
    private float altitude;
    private bool isPaused;
    private bool allreadyCollide;

    public Rigidbody2D playerRB;

    public Camera mainCamera;

    public static Action<float> OnUpdateHighScore;
    public static Action OnSaveHighScore;
    private void Awake()
    {
        playerRB.gravityScale = gravity;
        lvl = 0;
        timerSec = 0;
        timerMin = 0;
    }
    void Start()
    {
        mainCamera = Camera.main;
        lvl += 1;
        victory = false;
        allreadyCollide = false;
        playerIsDeath = false;   
        this.GetComponent<SpriteRenderer>().enabled = true;
    }

    void Update()
    {
        altitude = (transform.position.y + baseMapAltitude) * 100; 
        verticalSpeed =  playerRB.velocity.y;
        horizontalSpeed = playerRB.velocity.x;
        timerSec += Time.deltaTime;
        if (timerSec >= 59)
        {
            timerSec = 0;
            timerMin++;
        }
        if (victory)
        { 
            score += scoreThisLevel;
            victory = false;
        }
        if (playerIsDeath)
        {
            this.GetComponent<SpriteRenderer>().enabled = false;
        }

        Vector3 viewportPos = mainCamera.WorldToViewportPoint(this.transform.position);

        if (viewportPos.x < 0 || viewportPos.x > 1)
        {
            OnSaveHighScore?.Invoke();
            playerRB.constraints = RigidbodyConstraints2D.FreezeAll;
            playerIsDeath = true;
        }
    }



    public void SetVictory(bool result)
    {
        victory = result;
    }
    public void SetScoreThisLevel(int multiplier)
    {
        scoreThisLevel = (defaultPointsPerLanding * multiplier);        
    }
    public void SetPlayerIsDeath(bool checkDeath)
    {
        playerIsDeath = checkDeath;
    }
    public void SetIsPaused(bool pauseState)
    {
        isPaused = pauseState;
    }
    public float GetHorizontalSpeed()
    {
        return horizontalSpeed;
    }
    public float GetPointsThisLvl()
    {
        return scoreThisLevel;
    }
    public float GetVerticalSpeed()
    {
        return verticalSpeed;
    }
    public float GetTimerMin()
    {
        return timerMin;
    }
    public float GetTimerSec()
    {
        return timerSec;
    }
    public bool GetIsPaused()
    {
        return isPaused;
    }

    public float GetAltitude()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down);
        float absoluteAltitude = (hit.distance - 0.28f);
        if (absoluteAltitude > 0) { altitude = absoluteAltitude * 10; }
        else { altitude = 0; }
        if (altitude < 0.1) { altitude = 0; }
        return altitude;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (Mathf.Abs(GetVerticalSpeed()) + Mathf.Abs(GetHorizontalSpeed()) > speedExcededToConsiderACrash)
        {
            OnSaveHighScore?.Invoke();
            playerRB.constraints = RigidbodyConstraints2D.FreezeAll;
            playerIsDeath = true;
        }
        else
        {
            if (playerRB.rotation < -degreesExcededToConsiderACrash || playerRB.rotation > degreesExcededToConsiderACrash)
            {
                OnSaveHighScore?.Invoke();
                playerRB.constraints = RigidbodyConstraints2D.FreezeAll;
                playerIsDeath = true;
            }
            else
            {
                playerRB.constraints = RigidbodyConstraints2D.FreezeAll;
                SetVictory(true);
                if (!allreadyCollide)
                {
                    for (int i = 1; i < 7; i++)
                    {
                        if (collision.gameObject.tag == "X"+i)
                        {
                            SetScoreThisLevel(i);
                        }
                    }
                    if (collision.gameObject.tag == "Map")
                    {
                        SetScoreThisLevel(1); 
                    }

                    OnUpdateHighScore?.Invoke(score);
                }
            }
        }
        allreadyCollide = true;
    }

    public void NewLvl()
    {
        OnUpdateHighScore?.Invoke(score);
        playerRB.constraints = RigidbodyConstraints2D.None;
        lvl += 1;
        victory = false;
        allreadyCollide = false;
        playerIsDeath = false;
        this.GetComponent<SpriteRenderer>().enabled = true;
    }
}
