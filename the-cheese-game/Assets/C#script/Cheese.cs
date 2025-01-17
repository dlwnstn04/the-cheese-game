using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cheese : Move
{
    SpriteRenderer sprite;
    Color CheeseColor;


    public float freshness = 0.5f;
    public float MaxFreshness = 0.5f;
    (int, int) MapSize = (12, 10);

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        CheeseColor = sprite.color;
    }
    public void Teleport()
    {
        transform.position = new Vector2(Random.Range(-6, 7), Random.Range(-5, 6));
    }

    public void AdjustFreshness(float freshness)
    {
        this.freshness = freshness;
        sprite.color = new Color(CheeseColor.r * freshness / MaxFreshness,
                                     CheeseColor.g * freshness / MaxFreshness,
                                     CheeseColor.b * freshness / MaxFreshness);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Teleport();
            AdjustFreshness(MaxFreshness);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Wall"))
        {
            AdjustFreshness(freshness - Time.deltaTime);

            if(freshness <= 0)
            {
                Teleport();
                AdjustFreshness(MaxFreshness);
            }
        }
    }
}
