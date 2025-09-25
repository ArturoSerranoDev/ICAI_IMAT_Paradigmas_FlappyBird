using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("Dependencies")]
    [SerializeField] private GameObject pipesPrefab;
    
    [Header("Parameters")]
    [SerializeField] private float spawnRate = 1f;
    [SerializeField] private float minHeight = -1f;
    [SerializeField] private float maxHeight = 2f;

  
    public void Spawn()
    {
        // How we create new objects in Unity
        GameObject newPipe = Instantiate(pipesPrefab, Vector3.zero,
            Quaternion.identity);
    }
}
