using System.Collections;
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
        victory = false;
        playerIsDeath = false;
    }

    // Update is called once per frame
    void Update()
    {
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
        return altitude;
    }
}
