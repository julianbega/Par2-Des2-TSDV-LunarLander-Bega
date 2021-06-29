using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject Map;
    public GameObject Player;
    public float time;
    public bool isPaused;


    public static GameManager instanceGameManager;

    public static GameManager Instance { get { return instanceGameManager; } }

    private void Awake()
    {
        if (instanceGameManager != null && instanceGameManager != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instanceGameManager = this;
        }
    }
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
