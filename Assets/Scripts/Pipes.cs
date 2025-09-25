using UnityEngine;

public class Pipes : MonoBehaviour
{
    [Header("Dependencies")]
    [SerializeField] private Transform top;
    [SerializeField] private Transform bottom;

    [Header("Parameters")]
    [SerializeField] private float speed = 2f;

    private void Start()
    {
        //leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 1f;
    }

    private void Update()
    {
        // transform.position += ...

     
    }

}
