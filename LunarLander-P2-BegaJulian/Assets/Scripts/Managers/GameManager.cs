using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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
    PlayerManager playerManager;
    public static GameManager instanceGameManager;
    private UIManager UI;


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
        Debug.Log("startGame");
        TextMeshProUGUI[] texts = FindObjectsOfType<TextMeshProUGUI>();
        for (int i = 0; i < texts.Length; i++)
        {
            texts[i].color = Color.white;
        }
        background = Instantiate(BackgroundPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        float randomXpos = Random.Range(0, 110.5f);
        map = Instantiate(MapPrefab, new Vector3(randomXpos * -1, 1.3f, 0), Quaternion.identity);
        Player = Instantiate(PlayerPrefab, new Vector3(-55f, 4f, 0), Quaternion.identity);
        playerManager = Player.GetComponent<PlayerManager>();
    }
    public void StartNewLvl()
    {
        UI = FindObjectOfType<UIManager>();
        UI.setEndLvl();
        Player.GetComponent<PlayerController>().NewLvl();
        float randomXpos = Random.Range(0, 110.5f);
        playerManager.NewLvl();
        map.transform.position = new Vector3(randomXpos * -1, 1.3f, 0);
        Player.transform.position = new Vector3(-55f, 4f, 0);
    }

    public void Pause()
    {
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
            playerManager.SetIsPaused(true);
        }
        else
        {
            Time.timeScale = 1;
            playerManager.SetIsPaused(false);
        }
    }

    public IEnumerator Wait1SecondAndStartGame()
    {
        Debug.Log("start corrutine");
        yield return new WaitForSeconds(2f);
        StartGame();
    }
    public void GoToGame()
    {
        Debug.Log("go to game");
        StartCoroutine(Wait1SecondAndStartGame());
    }
}
