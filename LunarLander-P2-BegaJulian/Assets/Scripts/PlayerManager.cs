﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour

{
    public float fuel;
    public float score;
    public float rotationSpeed;
    public float propultionSpeed;
    public int lvl;
    public float defaultPointsPerLanding;
    private bool victory;
    private bool playerIsDeath;

    private float horizontalSpeed;
    private float verticalSpeed;
    private float altitude;
    public bool isPaused;

    public Rigidbody2D playerRB;
    void Start()
    {
        lvl = 1;
        victory = false;
        playerIsDeath = false;
    }

    // Update is called once per frame
    void Update()
    {
        altitude = (transform.position.y + 5) * 100;
        verticalSpeed =  playerRB.velocity.y;
        horizontalSpeed = playerRB.velocity.x;

    }


    
    public void SetVictory(bool result)
    {
        victory = result;
    }
    public void SetPlayerIsDeath(bool checkDeath)
    {
        playerIsDeath = checkDeath;
    }

    public float GetHorizontalSpeed()
    {
        return horizontalSpeed;
    }
    public float GetVerticalSpeed()
    {
        return verticalSpeed;
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
}
