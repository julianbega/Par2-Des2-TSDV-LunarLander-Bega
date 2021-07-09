using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CustomSceneManager : MonoBehaviour
{
    public string actualScene;
    public static CustomSceneManager instanceSceneManager;

    public static CustomSceneManager Instance { get { return instanceSceneManager; } }

    private void Awake()
    {
        actualScene = "Menu";
        if (instanceSceneManager != null && instanceSceneManager != this)
        {
            Destroy(FindObjectOfType<CustomSceneManager>().gameObject);
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
       SceneManager.LoadScene(scene);
    }


    public void OnClickQuit()
    {
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

}
