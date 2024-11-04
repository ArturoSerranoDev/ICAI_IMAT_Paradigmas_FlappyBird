using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Dependencies")]
    public Player player;
    public Spawner spawner;

    public TextMeshProUGUI scoreText; // How we reference a text component of TMPro in Unity's UI
    
    public GameObject playButton;
    public GameObject gameOver;

    public int Score;
    public float timeToSpawn = 5;
    public float elapsedTime;
    
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

        spawner.DestroyAllPipes();

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
