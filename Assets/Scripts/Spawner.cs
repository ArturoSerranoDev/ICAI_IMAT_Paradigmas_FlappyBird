using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("Dependencies")]
    public GameObject pipesPrefab;
    
    [Header("Parameters")]
    public float spawnRate = 1f;
    public float minHeight = -1f;
    public float maxHeight = 2f;

    private List<Pipes> pipes = new List<Pipes>();

    public void DestroyAllPipes()
    {
        foreach (Pipes pipe in pipes)
        {
            Destroy(pipe.gameObject);
        }

        pipes.Clear();
    }
    public void Spawn()
    {
        // How we create new objects in Unity
        GameObject newPipe = Instantiate(pipesPrefab, Vector3.zero,
            Quaternion.identity);

        pipes.Add(newPipe.GetComponent<Pipes>());

        newPipe.transform.position += Vector3.up * 
            Random.RandomRange(minHeight, maxHeight);

        newPipe.transform.position += Vector3.right * 5;
    }
}
