﻿using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Dependencies")]
    public Sprite[] sprites;

    [Header("Parameters")]
    public float strength = 5f;
    
    private const float Gravity = -9.81f;
    
    private SpriteRenderer spriteRenderer;
    
    private Vector3 direction;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {

        // izq
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            direction += Vector3.up * strength;
        }


        // Apply gravity and update the position
        // Time.deltaTime is applied twice because acceleration is in m/s^2
        direction.y += Gravity * Time.deltaTime ;
        transform.position += direction * Time.deltaTime;



        transform.rotation = Quaternion.Euler(0, 0, direction.y * 10);
    }

    private void AnimateSprite()
    {
  
    }

    // Bad practice, since Player shouldn't call methods on GameManager
    // This is just for demonstration purposes
    // A correct pattern would be to use events
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Obstacle")) 
        {
            direction = Vector3.zero;
            
            FindObjectOfType<GameManager>().GameOver();
        } 
        else if (other.gameObject.CompareTag("Scoring")) 
        {
            FindObjectOfType<GameManager>().IncreaseScore();
        }
    }

}
