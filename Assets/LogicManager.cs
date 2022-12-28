using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class LogicManager : MonoBehaviour
{
    public int score = 0;
    public Text scoreText;
    public Text highScore;
    public GameObject gameOverScreen;
    public GameObject homeScreen;
    public BirdScript bird;
    public PipeSpawner pipeSpawner;

    void Start()
    {
        bird = GameObject.FindGameObjectWithTag("Bird").GetComponent<BirdScript>();
        bird.myRigidBody2D.gravityScale = 0;

        pipeSpawner = GameObject.FindGameObjectWithTag("PipeSpawner").GetComponent<PipeSpawner>();

        homeScreen.SetActive(true);

        displayHighScore();
    }

    public void addScore() 
    {
        score++;
        scoreText.text = score.ToString();
    }

    public void setHomeScreen() 
    {
        gameOverScreen.SetActive(false);
        homeScreen.SetActive(true);
        displayHighScore();
        resetBird();
        score = 0;
        scoreText.text = score.ToString();
    }

    public void playGame()
    {
        homeScreen.SetActive(false);
        bird.alive = true;
        bird.myRigidBody2D.gravityScale = 4;
        pipeSpawner.spawnPipe();
        highScore.text = "";
    }

    public void restartGame()
    {
        gameOverScreen.SetActive(false);
        bird.myRigidBody2D.position = new Vector3(0, 0, 0);
        bird.myRigidBody2D.velocity = new Vector2(0, 0);
        bird.myRigidBody2D.gravityScale = 4;
        bird.alive = true;
        highScore.text = "";
        bird.myRigidBody2D.angularVelocity = 0;
        score = 0;
        scoreText.text = score.ToString();
    }

    public void gameOver()
    {
        gameOverScreen.SetActive(true);
        if (score > PlayerPrefs.GetInt("highScore"))
            PlayerPrefs.SetInt("highScore", score);
    }

    public void displayHighScore()
    {
        if (PlayerPrefs.HasKey("highScore"))
            if (PlayerPrefs.GetInt("highScore") != -1)
                highScore.text = $"High Score: {PlayerPrefs.GetInt("highScore")}";
            else
                highScore.text = "";
        else
            PlayerPrefs.SetInt("highScore", -1);
    }

    public void resetBird()
    {
        bird.transform.position = new Vector3(0, 0, 0);
        bird.myRigidBody2D.gravityScale = 0;
        bird.myRigidBody2D.velocity = new Vector2(0, 0);
        bird.myRigidBody2D.angularVelocity = 0;
        bird.transform.rotation = Quaternion.identity;
    }
}