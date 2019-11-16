using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidField : MonoBehaviour
{
    List<Asteroid> asteroids = new List<Asteroid>();
    [Header("Prefab")]
    public Asteroid asteroid;
    [Header("Width of line where asteroids will spawn")]
    public float  width = 300;
    Transform startPoint;
    [Header("Asteroid count")]
    public int asteriodCount = 10;
    [Header("Distance beetwen asteroids")]
    public float minOffset = 10 ,maxOffset = 15;
    public float angle = 0;

    int unactive = 0;
    float timer = 0;
    float spawnTimer = 0;
    void Start()
    {
        startPoint = transform;
        for (int i = 0; i < asteriodCount; i++)
            asteroids.Add(Instantiate(asteroid, this.transform));
        StartAsteroids();
    }

    void Update()
    {
        StartAsteroids();
        spawnTimer += Time.deltaTime;
    }

    void StartAsteroids()
    {
        float nextY = startPoint.position.y;
        float nextX = startPoint.position.x;
        foreach (Asteroid a in asteroids)
        {
            if (spawnTimer > Random.Range(0.2f, 0.4f))
            {
                if (!a.enabled)
                {
                    Debug.Log(transform.position.y + transform.position.y * Mathf.Sin(angle));
                    Spawn(a, new Vector2(startPoint.position.x + Random.Range(minOffset, maxOffset) * Mathf.Cos(angle), startPoint.position.y + Random.Range(minOffset, maxOffset) * Mathf.Sin(angle)));
                    minOffset += 5;
                    maxOffset += 5;
                    if (maxOffset > width)
                    {
                        minOffset = 10;
                        maxOffset = 20;
                    }
                }
                spawnTimer = 0;
            }
        }
    }

    void Spawn(Asteroid a, Vector2 coords)
    {
        a.ResetSprite();
        a.SetDirection(angle);
        a.transform.position = coords;
    }
}
