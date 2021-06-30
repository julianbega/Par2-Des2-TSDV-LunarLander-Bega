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
    public bool victory;
    private bool playerIsDeath;
    private float scoreThisLevel;

    public int timerMin;
    public float timerSec;


    public Animator Explotion;

    private float horizontalSpeed;
    private float verticalSpeed;
    private float altitude;
    public bool isPaused;

    public Rigidbody2D playerRB;
    private void Awake()
    {
        lvl = 0;
    }
    void Start()
    {
        lvl += 1;
        victory = false;
        playerIsDeath = false;
        timerSec = 0;
        timerMin = 0;
        this.GetComponent<SpriteRenderer>().enabled = true;
    }

    void Update()
    {
        altitude = (transform.position.y + 5) * 100;
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
            Explotion.SetBool("Die", true);
            this.GetComponent<SpriteRenderer>().enabled = false;
        }
        
    }



    public void SetVictory(bool result)
    {
        victory = result;
    }
    public void SetScoreThisLevel(int multiplier)
    {
        scoreThisLevel = defaultPointsPerLanding * multiplier;
        
    }
    public void SetPlayerIsDeath(bool checkDeath)
    {
        playerIsDeath = checkDeath;
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
