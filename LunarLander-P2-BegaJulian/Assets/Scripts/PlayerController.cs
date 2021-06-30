﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public PlayerManager manager;

    public bool allreadyCollide;
    public bool isDead;
    // Start is called before the first frame update
    void Start()
    {
        allreadyCollide = false;
        isDead = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!allreadyCollide)
        {
            if (Input.GetKey(KeyCode.A))
            { manager.playerRB.transform.Rotate(Vector3.forward * Time.deltaTime * manager.rotationSpeed, Space.Self); }
            if (Input.GetKey(KeyCode.D))
            { manager.playerRB.transform.Rotate(-Vector3.forward * Time.deltaTime * manager.rotationSpeed, Space.Self); }

            if (Input.GetKey(KeyCode.Space) && manager.fuel > 0)
            {
                manager.playerRB.AddForce(transform.up * Time.deltaTime * manager.propultionSpeed);
                manager.fuel -= 10 * Time.deltaTime;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        allreadyCollide = true;
        
        if(Mathf.Abs(manager.playerRB.velocity.x) + Mathf.Abs(manager.playerRB.velocity.y) > 1)
        {
            isDead = true;
        }
    }


}
