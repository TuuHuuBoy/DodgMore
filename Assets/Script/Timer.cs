using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    
    public float gameTime = 0;
    private bool isTimerRunning = true;
    private float timer;
    public Text timerText;
    public Text gameOverText;
    public Player player;

    // Update is called once per frame
    void Update()
    {
        if (isTimerRunning)
        {
            gameTime += Time.deltaTime;
            timer += Time.deltaTime;
            if (timer >= 60.0f)
            {
                gameTime -= 59.0f;
                timer = 0.0f;
            }
            timerText.text = "Time: " + Mathf.Floor(gameTime).ToString();

            if (player.isDead)
            {
                isTimerRunning = false;
                gameOverText.gameObject.SetActive(true);
                gameOverText.text = "Game Over\nTime: " + Mathf.Floor(gameTime).ToString();
                SceneManager.LoadScene("Game Over");
            }
        }
    }
}
