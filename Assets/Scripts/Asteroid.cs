using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float speed = 5f;
    Rigidbody2D rb;
    Object[] res;
    public List<Sprite> sprites = new List<Sprite>();
    public float lifeTime = 10f;
    Vector2 direction;
    float timer = 0;
    float spawnTimer = 0;
    void Start()
    {
        direction = transform.up;
        //speed = Random.Range(speed - 10, speed + 10);
        rb = GetComponent<Rigidbody2D>();
        ResetSprite();
    }

    void Update()
    {
        Move(direction);
        timer += Time.deltaTime;
    }

    void Move(Vector2 direction)
    {
        rb.velocity = direction * speed * Time.deltaTime;
        if (timer > lifeTime)
        {
            enabled = false;
            timer = 0;
        }
    }

    public void ResetSprite()
    {
        GetComponent<SpriteRenderer>().sprite = sprites[(int)Random.Range(0, sprites.Count)];
        enabled = true;
        if (rb != null)
        {
            rb.inertia = 0;
            rb.velocity = Vector2.zero;
        }
        else
        {
            rb = GetComponent<Rigidbody2D>();
        }
    }

    public void SetDirection(float angle)
    {
        this.direction = transform.up * Mathf.Tan(angle);
        direction.Normalize();
        transform.rotation = Quaternion.Euler(0, 0, angle * 180 / 3.14f);
    }


}
