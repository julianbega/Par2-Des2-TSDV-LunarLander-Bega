using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashScreen : MonoBehaviour
{
    public Sprite firstSplashScreen;
    public Sprite secondSplashScreen;
    public Sprite splashScreenBackground;

    CanvasGroup canvasToFade;
    private void Start()
    {
        canvasToFade = this.GetComponent<CanvasGroup>();
    }
    void Update()
    {
    }
}
