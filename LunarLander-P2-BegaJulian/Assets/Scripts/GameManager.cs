using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject MapPrefab;
    public GameObject PlayerPrefab;
    public GameObject BackgroundPrefab;
    public float time;
    public bool isPaused;
    GameObject map;
    GameObject background;
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
            Pause();
        }
    }

   public void StartGame()
    {
        Canvas UI = FindObjectOfType<Canvas>();
        UI.sortingOrder = 0;
        background = Instantiate(BackgroundPrefab, new Vector3(0, 0, 0), Quaternion.identity);
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

    public void Pause()
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

    public IEnumerator Wait1SecondAndStartGame()
    {
        yield return new WaitForSeconds(2f);
        StartGame();
    }
    public void GoToGame()
    {
        StartCoroutine(Wait1SecondAndStartGame());
    }
}
