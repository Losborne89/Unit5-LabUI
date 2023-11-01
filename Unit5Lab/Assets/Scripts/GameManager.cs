using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    private float spawnRate = 1.0f;

    private int score;
    public TextMeshProUGUI scoreText;

    // Start is called before the first frame update
    void Start()
    {
        // Starts spawn timer
        StartCoroutine(SpawnTarget());

        score = 0;
        scoreText.text = "Score: " + score;
        UpdateScore(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnTarget()
    {
        while (true)
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
}
