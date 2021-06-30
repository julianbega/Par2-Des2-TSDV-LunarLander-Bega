﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    //---------------- Player------------------
    public TextMeshProUGUI score;
    public TextMeshProUGUI time;
    public TextMeshProUGUI fuel;
    public TextMeshProUGUI horizontalSpeed;
    public TextMeshProUGUI verticalSpeed;
    public TextMeshProUGUI lvl;
    public TextMeshProUGUI altitude;
 
  // public Button BackToMenu;
   // public Button Resume;
    public Image Controls;
    private PlayerManager player = null;

    //---------------- EndLvl------------------
    public Button Next;
    public Button ToMenu;
    public Image Panel;
    public TextMeshProUGUI FinalScore;
    public TextMeshProUGUI GameResult;

    void LateStart()
    {
        player = FindObjectOfType<PlayerManager>();
        setEndLvl();
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null)
        {
            player = FindObjectOfType<PlayerManager>(); 
        }

        if (player != null)
            {
            score.text = "Score: " + player.score.ToString();
            // time.text = "Time:" + player.score.ToString();
            time.text = "Timer: " + player.GetTimerMin() + " : " + (float)Mathf.Round(player.GetTimerSec());
            fuel.text = "Fuel:" + player.fuel.ToString();
            horizontalSpeed.text = "HorizontalSpeed:" + player.GetHorizontalSpeed().ToString("F2");
            verticalSpeed.text = "VerticalSpeed:" + player.GetVerticalSpeed().ToString("F2");
            altitude.text = "Altitude:" + player.GetAltitude().ToString();
            lvl.text = "Level:" + player.lvl.ToString();

            if (player.GetIsPaused() == true)
            {
                // BackToMenu.gameObject.SetActive(true);
                //  Resume.image.enabled = true;
                Controls.enabled = true;
            }
            else
            {
              //  BackToMenu.gameObject.SetActive(false);
                //   Resume.image.enabled = false;
                Controls.enabled = false;
            }

            if (player.victory == true || player.playerIsDeath == true)
            {
                GameResult.gameObject.SetActive(true);
                Panel.gameObject.SetActive(true);
                FinalScore.gameObject.SetActive(true);
                if (player.victory)
                {
                    Next.gameObject.SetActive(true);
                    GameResult.text = "You landed";
                }
                else 
                {
                    ToMenu.gameObject.SetActive(true);
                    GameResult.text = "You crash";
                }
               
            }
            if (FinalScore.gameObject.active)
            {
                FinalScore.text = "Final Score: " + player.score.ToString();
            }
        }

       
    }

    public void setEndLvl()
    {
        ToMenu.gameObject.SetActive(false);
        Next.gameObject.SetActive(false);
        Panel.gameObject.SetActive(false);
        FinalScore.gameObject.SetActive(false);
        GameResult.gameObject.SetActive(false);
    }
}
