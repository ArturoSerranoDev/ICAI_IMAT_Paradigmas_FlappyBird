using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Dependencies")]
    [SerializeField] private Sprite[] sprites;

    [Header("Parameters")]
    [SerializeField] private float strength = 5f;
    
    private const float Gravity = -9.81f;
    
    private SpriteRenderer spriteRenderer;
    private Vector3 direction;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
        }

        // Apply gravity and update the position
        // Time.deltaTime is applied twice because acceleration is in m/s^2
        direction.y += Gravity * Time.deltaTime ;
        transform.position += direction * Time.deltaTime;
    }

    private void AnimateSprite()
    {
  
    }

    // Bad practice, since Player shouldn't call methods on GameManager
    // This is just for demonstration purposes
    // A correct pattern would be to use events
    private void OnTriggerEnter2D(Collider2D other)
    {
        // TODO: Implement collision detection with obstacles and scoring triggers
    }

}
