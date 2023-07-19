using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Database database;
    public TextMeshProUGUI scoreText;
    public GameObject finalPanel;
    public TextMeshProUGUI finalScore;
    public TextMeshProUGUI coinText;
    public TextMeshProUGUI finalHighScore;
    private bool turn;
    private float speed = 5f;
    private int score = 0;

    private void Awake()
    {
        Time.timeScale = 0f;
        coinText.text = database.coin.ToString();
    }

    void Update()
    {
        BallMove();
        if (Time.timeScale != 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                turn = !turn;
                score++;
                scoreText.text = score.ToString();
            }
        }
        if (transform.position.y <= 1f)
        {
            if (database.highScore < score)
                database.highScore = score;
            Time.timeScale = 0;
            finalPanel.SetActive(true);
            scoreText.text = "";
            finalScore.text = score.ToString();
            finalHighScore.text = database.highScore.ToString();
        }



    }
    private void BallMove()
    {
        if (turn)
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        else
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void StartGame()
    {

        Time.timeScale = 1f;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "coin")
        {
            database.coin++;
            coinText.text = database.coin.ToString();
            Destroy(other.gameObject);
        }
    }

}
