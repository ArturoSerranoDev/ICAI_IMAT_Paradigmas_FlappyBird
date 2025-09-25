using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Dependencies")]
    [SerializeField] private Player player;
    [SerializeField] private Spawner spawner;

    [SerializeField] private TextMeshProUGUI scoreText; // How we reference a text component of TMPro in Unity's UI
    
    [SerializeField] private GameObject playButton;
    [SerializeField] private GameObject gameOver;

    [SerializeField] private int Score;
    [SerializeField] private float timeToSpawn = 5;
    [SerializeField] private float elapsedTime;
    
    private void Start()
    {
        Pause();
    }

    // Another way in Unity to create timed functions
    private IEnumerator SpawnCoroutine()
    {
        while (true)
        {
            spawner.Spawn();
            yield return new WaitForSeconds(5);
        }
    }

    public void Play()
    {
        Score = 0;
        scoreText.text = Score.ToString();

        playButton.SetActive(false);
        gameOver.SetActive(false);

        Time.timeScale = 1f;
        player.enabled = true;
        
        player.transform.position = Vector3.zero;

        Pipes[] pipes = FindObjectsOfType<Pipes>();

        for (int i = 0; i < pipes.Length; i++) 
        {
            Destroy(pipes[i].gameObject);
        }
    }

    private void Update()
    {
        elapsedTime += Time.deltaTime;

        if (elapsedTime > timeToSpawn)
        {
            spawner.Spawn();
            elapsedTime = 0;
        }
    }

    public void GameOver()
    {
        playButton.SetActive(true);
        gameOver.SetActive(true);
        
        Pause();
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        player.enabled = false;
    }

    public void IncreaseScore()
    {
        Score++;
        scoreText.text = Score.ToString();
    }
}
