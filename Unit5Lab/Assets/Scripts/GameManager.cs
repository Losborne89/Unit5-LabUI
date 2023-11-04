using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public Button restartButton;
    public GameObject titleScreen;
    
    public bool IsGameActive;
    private int score;
    private float spawnRate = 1.0f;
    

    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnTarget()
    {
        // Runs only when game is active
        while (IsGameActive)
        {
            // Spawns random object over time - every 1 second 
            yield return new WaitForSeconds(spawnRate);
            // Chooses random object from list
            int index = Random.Range(0, targets.Count);
            // Grabs object from targets list 
            Instantiate(targets[index]);
        }
       
    }

    public void UpdateScore(int scoreToAdd)
    {
        // Adds score to text 
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
        // When game over Restart Button shows
        restartButton.gameObject.SetActive(true);
        // Game Over text shows
        gameOverText.gameObject.SetActive(true);
        // Game Over game stops
        IsGameActive = false;
    }

    public void RestartGame()
    {
        // Reloads scene when Restart button clicked
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame(int difficulty)
    {
        // Set first to start game and start score
        IsGameActive = true;
        score = 0;

        // Sets difficulty spawn rate
        spawnRate /= difficulty;

        // Spawn timer starts and score updated
        StartCoroutine(SpawnTarget());
        UpdateScore(0);

        // Turns title screen off once button clicked
        titleScreen.gameObject.SetActive(false);
    }
}
