using UnityEngine;

public class Pipes : MonoBehaviour
{
    [Header("Dependencies")]
    public Transform top;
    public Transform bottom;

    [Header("Parameters")]

    public float leftEdge;
    public float strength = 2f;

    private void Start()
    {
        //leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 1f;
    }

    private void Update()
    {
        transform.position += Vector3.left * strength;

        if (transform.position.x < leftEdge)
        {
            Destroy(gameObject);
        }
    }

}
