using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject MapPrefab;
    public GameObject PlayerPrefab;
    public float time;
    public bool isPaused;
    GameObject map;
    GameObject Player;
    public PlayerManager playerManager;
    public static GameManager instanceGameManager;
    private UIManager UI;
    public PlayerData actualPlayer;
    public PlayerData highScore;
    public static GameManager Instance { get { return instanceGameManager; } }

    const float playerStartingXPos = -55f;
    const float playerStartingYPos = 4f;
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
        PlayerManager.OnSaveHighScore += SaveHighScore;
        PlayerManager.OnUpdateHighScore += UpdateScore;
        highScore = SaveSystem.LoadHighScore();
        if (actualPlayer.playerName == "") actualPlayer.playerName = "NN";
        DontDestroyOnLoad(this.gameObject);
    }
    private void OnDisable()
    {
        PlayerManager.OnSaveHighScore -= SaveHighScore;
        PlayerManager.OnUpdateHighScore -= UpdateScore;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }

    }
    public void SaveHighScore()
    {
        if (highScore != null)
        {
            if (playerManager.score > highScore.score)
            {
                SaveSystem.SaveHighScore(actualPlayer);
                SaveSystem.LoadHighScore();
            }
        }
        else
        {
            SaveSystem.SaveHighScore(actualPlayer);
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
        float randomXpos = Random.Range(0, 110.5f);
        map = Instantiate(MapPrefab, new Vector3(randomXpos * -1, 1.3f, 0), Quaternion.identity);
        Player = Instantiate(PlayerPrefab, new Vector3(playerStartingXPos, playerStartingYPos, 0), Quaternion.identity);
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
        StartCoroutine(Wait1SecondAndStartGame());
    }

    public void ReadPlayersName(string name)
    {
        Debug.Log("Lee el name");
        actualPlayer.playerName = name;
        Debug.Log(actualPlayer.playerName);
    }

    public float GetLastScore()
    {
        return actualPlayer.score;
    }
    public void UpdateScore(float score)
    {
        actualPlayer.score = score;
    }
}
