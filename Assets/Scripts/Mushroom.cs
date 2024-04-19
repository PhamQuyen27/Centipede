using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : MonoBehaviour
{
    public Sprite[] states;
    private SpriteRenderer SpriteRenderer;
    private int health;
    public int points = 1;

    private void Awake()
    {
        SpriteRenderer = GetComponent<SpriteRenderer>();
        health = states.Length;
    }


    private void Damage(int amount)
    {
        health -= amount;
        if( health > 0 )
        {
            SpriteRenderer.sprite = states[states.Length - health];
        }
        else
        {
            Destroy(gameObject);
            GameManager.Instance.IncreaseScore(points);
        }
    }

    public void Heal()
    {
        health = states.Length;
        SpriteRenderer.sprite = states[0];
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Dart"))
        {
            Damage(1);
        }
    }
}
