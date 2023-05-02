using UnityEngine;
using UnityEngine.UI;


public class GameOver : MonoBehaviour
{
    public Text timeText;
    

    void Awake()
    {
        float gameTime = PlayerPrefs.GetFloat("GameTime", 0.0f);
        timeText.text = "Your Time: " + Mathf.Floor(gameTime).ToString() + " seconds";
        PlayerPrefs.DeleteKey("GameTime");
    }
}
