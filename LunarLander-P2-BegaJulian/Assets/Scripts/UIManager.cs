﻿using System.Collections;
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
    public TextMeshProUGUI altitude;

    private PlayerManager player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>();
    }

    // Update is called once per frame
    void Update()
    {
        score.text = "Score:" + player.score.ToString();
        // time.text = "Time:" + player.score.ToString();
        fuel.text = "Fuel:" + player.fuel.ToString();
        horizontalSpeed.text = "HorizontalSpeed:" + player.horizontalSpeed.ToString("F2");
        verticalSpeed.text = "VerticalSpeed:" + player.verticalSpeed.ToString("F2");
        altitude.text = "Altitude:" + player.altitude.ToString();
    }
}
