using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneManager : MonoBehaviour
{
    public string actualScene;
    public static SceneManager instanceSceneManager;

    public static SceneManager Instance { get { return instanceSceneManager; } }

    private void Awake()
    {
        actualScene = "Menu";
        if (instanceSceneManager != null && instanceSceneManager != this)
        {
            Destroy(FindObjectOfType<SceneManager>().gameObject);
        }
        else
        {
            instanceSceneManager = this;
        }
    }

    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    private void OnDisable()
    {
    }

    public void ChangeScene(string scene)
    {
        Debug.Log("Cambia de escena a" + scene);
        actualScene = scene;
        UnityEngine.SceneManagement.SceneManager.LoadScene(scene);
    }
    

    public void OnClickQuit()
    {
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

}