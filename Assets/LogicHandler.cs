using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LogicHandler : MonoBehaviour
{
    public GameObject gameOver;
    public GameObject gameReady;
    public GameObject planeGO;
    public GameObject spawnerGO;
    public GameObject scoreGO;
    private Rigidbody2D planeBody2D;

    public GameObject overScore;
    private bool ready;
    private ScoreCounter scoreCounter;

    // Start is called before the first frame update
    void Start()
    {
        planeBody2D = planeGO.GetComponent<Rigidbody2D>();
        scoreCounter = scoreGO.GetComponent<ScoreCounter>();
        Idle();
    }
    void Update()
    {
        if (!ready && Input.GetKeyDown(KeyCode.Space))
        {
            ready = true;
            gameReady.SetActive(false);
            planeBody2D.simulated = true;
            spawnerGO.SetActive(true);
        }
    }
    public void UpdateScore(int add)
    {
        scoreCounter.AddScore(add);
    }
    void Idle()
    {
        ready = false;
        gameReady.SetActive(true);
        planeBody2D.simulated = false;
        spawnerGO.SetActive(false);
    }
    void Restart()
    {
        gameOver.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void GameOver()
    {
        if (scoreCounter.score > (PlayerPrefs.HasKey("highscore") ? PlayerPrefs.GetInt("highscore") : 0))
        {
            PlayerPrefs.SetInt("highscore", scoreCounter.score);
        }
        overScore.GetComponent<Text>().text = "SCORE: " + scoreCounter.score.ToString();
        gameOver.SetActive(true);
    }

}
