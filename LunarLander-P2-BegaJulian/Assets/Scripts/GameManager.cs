using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject Map;
    public GameObject Player;
    public float time;
    public bool isPaused;
    // Start is called before the first frame update
    void Start()
    {
        UpdateMap();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdateMap()
    {
        float randomXpos = Random.Range(0, 110.5f);
        Map.transform.position = new Vector3(randomXpos * -1, 1.3f, 0);
    }
}
