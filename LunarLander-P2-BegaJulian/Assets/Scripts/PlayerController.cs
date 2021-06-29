using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public PlayerStats stats;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        { stats.playerRB.transform.Rotate(Vector3.forward * Time.deltaTime * stats.rotationSpeed, Space.Self); }
        if (Input.GetKey(KeyCode.D))
        { stats.playerRB.transform.Rotate(-Vector3.forward * Time.deltaTime * stats.rotationSpeed, Space.Self); }

        if (Input.GetKey(KeyCode.Space) && stats.fuel > 0)
        { 
            stats.playerRB.AddForce(transform.up * Time.deltaTime * stats.propultionSpeed);
            stats.fuel -= 10 * Time.deltaTime;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       // if(stats.playerRB.velocity.x >)
    }
}
