using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour

{
    public float fuel;
    public float score;
    public float rotationSpeed;
    public float propultionSpeed;

    public float horizontalSpeed;
    public float verticalSpeed;
    public float altitude;
    public bool isPaused;

    public Rigidbody2D playerRB;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        verticalSpeed =  playerRB.velocity.y;
        horizontalSpeed = playerRB.velocity.x;
    }
}
