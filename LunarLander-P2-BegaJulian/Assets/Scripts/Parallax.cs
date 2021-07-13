using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public List<GameObject> planets;    
    public List<float> planetsSpeed;
    private List<Vector3> planetsStartingPos;
    public float parallaxXLimit;
    private bool start;
    public float timeToStartParallax;

    public List<GameObject> background;
    public float backgroundSpeed;
    public float backgroundParallaxXLimit;
    private Vector3 backgroundParallaxStartingPos;


    public SpriteRenderer Level1Sign;
    void Start()
    {
        planetsStartingPos = new List<Vector3>();
        backgroundParallaxStartingPos = background[0].transform.position;
        start = false;
        for (int i = 0; i <= planets.Count-1; i++)
        {
            planetsStartingPos.Add(planets[i].transform.position);
        }
    }
    void Update()
    {
        if (start)
        {
            for (int i = 0; i <= planets.Count-1; i++)
            {
                if (planets[i].transform.position.x <= parallaxXLimit)
                {
                    planets[i].transform.position = planetsStartingPos[i];
                }
                planets[i].transform.position = (planets[i].transform.position + (Vector3.left * (planetsSpeed[i] / 3) * Time.deltaTime));
            }
            for (int i = 0; i <= background.Count-1; i++)
            {
                if (background[i].transform.position.x <= backgroundParallaxXLimit)
                {
                    background[i].transform.position = backgroundParallaxStartingPos;
                }
                background[i].transform.position = (background[i].transform.position + (Vector3.left * (backgroundSpeed / 3) * Time.deltaTime));
            }
        }
        ParallaxCountDown();
    }

    public IEnumerator WaitAndStartParallax()
    {
        yield return new WaitForSeconds(timeToStartParallax);
        start = true;
        Level1Sign.enabled = false;
    }
    public void ParallaxCountDown()
    {
        StartCoroutine(WaitAndStartParallax());
    }
}
