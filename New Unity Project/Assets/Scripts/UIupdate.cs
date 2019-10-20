using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIupdate : MonoBehaviour
{
    public Transform trainPosition;
    public Text scoreText;
    public Text gameOverText;
    private int score;

    private float timer;

    public static bool gameOver;

    // Start is called before the first frame update
    void Start()
    {
        score = (int)trainPosition.position.z;
        timer = 0f;
        gameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        //score = (int)trainPosition.position.z*10;
        scoreText.text = score.ToString();

        if(gameOver)
        {
            gameOverText.gameObject.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    private void FixedUpdate()
    {
        timer += Time.fixedDeltaTime;
        if (timer >= 1f/TrainMovement.speedOfTrain)
        {
            score += 10;
            timer = 0f;
        }
    }

    
}
