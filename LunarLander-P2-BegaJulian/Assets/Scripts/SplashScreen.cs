using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;

public class SplashScreen : MonoBehaviour
{
    public CanvasGroup hardGamesSplash;
    public CanvasGroup lunarLanderSplash;

    bool isInLunarLander;
    bool isInHardGames;

    public SceneManager scm;
    private void Start()
    {
        isInLunarLander = false;
        isInHardGames = true;
        hardGamesSplash.alpha = 1f;
        lunarLanderSplash.alpha = 0;
        StartSplash();


    }
    public IEnumerator WaitAndStartSplash()
    {
        yield return new WaitForSeconds(2f);
        while (hardGamesSplash.alpha > 0)
        {
            hardGamesSplash.alpha -= Time.deltaTime;
            yield return new WaitForSeconds(0.01f);
        }
        if (hardGamesSplash.alpha <= 0)
        {
            while (lunarLanderSplash.alpha < 1)
            {
                lunarLanderSplash.alpha += Time.deltaTime;
                yield return new WaitForSeconds(0.01f);
            }
            if (lunarLanderSplash.alpha >= 1)
            {
                yield return new WaitForSeconds(2f);
            }
            scm.ChangeScene("Menu");
        }
    }
    public void StartSplash()
    {
        Debug.Log("go to game");
        StartCoroutine(WaitAndStartSplash());
    }
}
