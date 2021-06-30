using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
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
    void LateStart()
    {
        player = FindObjectOfType<PlayerManager>();
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
            score.text = "Score:" + player.score.ToString();
            // time.text = "Time:" + player.score.ToString();
            time.text = "Timer: " + player.GetTimerMin() + " : " + (float)Mathf.Round(player.GetTimerSec());
            fuel.text = "Fuel:" + player.fuel.ToString();
            horizontalSpeed.text = "HorizontalSpeed:" + player.GetHorizontalSpeed().ToString("F2");
            verticalSpeed.text = "VerticalSpeed:" + player.GetVerticalSpeed().ToString("F2");
            altitude.text = "Altitude:" + player.GetAltitude().ToString();
            lvl.text = "Level:" + player.lvl.ToString();

            if (player.isPaused)
            {
               // BackToMenu.image.enabled = true;
              //  Resume.image.enabled = true;
                Controls.enabled = true;
            }
            else
            {
            //    BackToMenu.image.enabled = false;
             //   Resume.image.enabled = false;
                Controls.enabled = false;
            }
        }

       
    }
}
