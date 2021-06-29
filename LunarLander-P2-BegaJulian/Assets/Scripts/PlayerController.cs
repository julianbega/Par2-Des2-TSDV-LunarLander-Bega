using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public PlayerManager manager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
       // if(stats.playerRB.velocity.x >)
    }


}
