using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShowHighScore : MonoBehaviour
{
    public TextMeshProUGUI highScore;
    public TextMeshProUGUI playerScore;
    public GameManager gm;
    void Start()
    {
        gm = FindObjectOfType<GameManager>();
        UpdateHighScoreText();
        
    }
    void UpdateHighScoreText()
    {
        playerScore.text = "Your Score is: " + gm.GetLastScore().ToString();
        if (gm.lastScore >= gm.highScore.score)
        {            
            highScore.text = "New HighScore!! ";
        }
        else
        {
            if (gm.highScore.playerName == "")
            {
                highScore.text = "The HighScore is " + gm.highScore.score + " by: NN";
            }
            else
            {
                highScore.text = "The HighScore is " + gm.highScore.score + " by: " + gm.highScore.playerName;
            }
        }
    }
}
