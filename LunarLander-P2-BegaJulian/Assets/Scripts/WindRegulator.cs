using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindRegulator : MonoBehaviour
{
    PlayerManager lvlGiver;
    public AreaEffector2D effect;
    int lvl;
    public int lvlToStartLowWind;
    public int lvlToStandardWind;
    public int lvlToStartHighWind;
    public float lowWind;
    public float standardWind;
    public float highWind;
    void Start()
    {
        lvlGiver = FindObjectOfType<PlayerManager>();
    }
    void Update()
    {
        if (lvlGiver == null)
        {
            lvlGiver = FindObjectOfType<PlayerManager>();
        }
        lvl = lvlGiver.lvl;

        if (lvl < lvlToStartLowWind)
        {
            effect.forceMagnitude = 0;
        }
        if (lvl > lvlToStartLowWind && lvl <= lvlToStandardWind)
        {
            effect.forceMagnitude = lowWind;
        }
        if (lvl > lvlToStandardWind && lvl <= lvlToStartHighWind)
        {
            effect.forceMagnitude = standardWind;
        }
        if (lvl >= lvlToStartHighWind)
        {

            effect.forceMagnitude = highWind;
        }
    }
}
