using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject MapPrefab;
    public GameObject PlayerPrefab;
    public float time;
    public bool isPaused;
    GameObject map;
    GameObject Player;

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
        DontDestroyOnLoad(this.gameObject);
       // StartGame();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale == 1)
            {
                Time.timeScale = 0;
            }
            else
            {
                Time.timeScale = 1;
            }
        }
    }

    void StartGame()
    {
       
        float randomXpos = Random.Range(0, 110.5f);
        map = Instantiate(MapPrefab, new Vector3(randomXpos * -1, 1.3f, 0), Quaternion.identity);
        Player = Instantiate(PlayerPrefab, new Vector3(-55f, 4f, 0), Quaternion.identity);
    }
    void StartNewLvl()
    {
        float randomXpos = Random.Range(0, 110.5f);
        map = Instantiate(MapPrefab, new Vector3(randomXpos * -1, 1.3f, 0), Quaternion.identity);
        Player.transform.position = new Vector3(-55f, 4f, 0);
    }
}
