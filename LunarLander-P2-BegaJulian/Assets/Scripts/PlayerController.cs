using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public PlayerManager manager;

    public bool allreadyCollide;
    public bool isDead;

    public ParticleSystem rocketFire;
    void Start()
    {
        allreadyCollide = false;
        isDead = false;
    }

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
                if (!rocketFire.isPlaying) rocketFire.Play();
            }
            else
            {
                rocketFire.Stop();
            }
        }
        else { rocketFire.Stop(); }

    }

    public void NewLvl()
    {
        allreadyCollide = false;
        isDead = false;
    }

    


}
