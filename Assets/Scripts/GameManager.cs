using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour

{

    public int lives;
    public int score;
    public Text livesText;
    public Text scoreText;
    public bool gameOver;
    public GameObject GOPanel;
    public GameObject VPanel;

    public int numOfBricks;

    // Start is called before the first frame update
    void Start()
    {
        livesText.text = "Lives:    " + lives;
        scoreText.text = "Score:    " + score;
        gameOver = false;
        numOfBricks = GameObject.FindGameObjectsWithTag("Brick").Length;
    }

    // Update is called once per frame
    void Update()
    {
        if (numOfBricks == 0)
        {
            Victory();
        }
    }

    public void UpdateLives(int changeInLives)
    {
        lives += changeInLives;
        livesText.text = "Lives:    " + lives;

        if(lives <= 0)
        {
            lives = 0;
            GameOver();
        }


    }

    public void UpdateScore(int changeInScore)
    {
        score += changeInScore;
        scoreText.text = "Score:    " + score;
    }

    public void UpdateBricks(int changeInBricks)
    {
        numOfBricks += changeInBricks;
    }

    void GameOver()
    {
        gameOver = true;
        GOPanel.SetActive(true);
    }

    void Victory()
    {
        gameOver = true;
        VPanel.SetActive(true);
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Game Quit");
    }

}
