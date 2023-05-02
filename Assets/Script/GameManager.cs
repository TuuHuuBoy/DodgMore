using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    public Text gameOverText;
    public float gameTime = 0;
    private bool isTimerRunning = true;
    private float timer = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

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
        }
    }

    public void GameOver()
    {
        isTimerRunning = false;
        gameOverText.gameObject.SetActive(true);
        gameOverText.text = "Game Over\nTime: " + Mathf.Floor(gameTime).ToString();
    }
}
