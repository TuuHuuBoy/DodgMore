using TMPro;
using UnityEngine;


public class NewTimer : MonoBehaviour
{
    private float timeDuration = 3f * 60f;

    private float timer;

    [SerializeField]
    private bool countDown = true;

    [SerializeField]
    private TextMeshProUGUI firstMinute;
    [SerializeField]
    private TextMeshProUGUI secondMinute;
    [SerializeField]
    private TextMeshProUGUI separator;
    [SerializeField]
    private TextMeshProUGUI firstSecond;
    [SerializeField]
    private TextMeshProUGUI secondSecond;

    private float flashTimer;
    private float flashDuration = 1f;

    void Start()
    {
            ResetTimer();
    }

    // Update is called once per frame
    void Update()
    {
        if(countDown && timer > 0)
        {
            timer -= Time.deltaTime;
            UpdateTimerDisplayer(timer);
        }
        else if (!countDown && timer < timeDuration){
            timer += Time.deltaTime;
            UpdateTimerDisplayer(timer);
        }
        else
        {
            Flash();
        }
    }

    private void ResetTimer()
    {
        if (countDown)
        {
            timer = timeDuration;
        }
        else
        {
            timer = 0;
        }

        SetTextDisplay(true);
    }

    private void UpdateTimerDisplayer(float time)
    {
        if(time < 0)
        {
            time = 0;
        }

        float minutes = Mathf.FloorToInt(time / 60);
        float seconds = Mathf.FloorToInt(time % 60);

        string currentTime = string.Format("{00:00}{1:00}", minutes, seconds);
        firstMinute.text = currentTime[0].ToString();
        secondMinute.text = currentTime[1].ToString();
        firstSecond.text = currentTime[2].ToString();
        secondSecond.text = currentTime[3].ToString();
    }

    private void Flash()
    {
        if(countDown && timer != 0)
        {
            timer = 0;
            UpdateTimerDisplayer(timer);
        }

        if(!countDown && timer != timeDuration)
        {
            timer = 0;
            UpdateTimerDisplayer(timer);
        }

        if(flashTimer <= 0)
        {
            flashTimer = flashDuration;
        }

        else if (flashTimer >= flashDuration / 2)
        {
            flashTimer -= Time.deltaTime;
            SetTextDisplay(false);
        }

        else
        {
            flashTimer -= Time.deltaTime;
            SetTextDisplay(true);
        }
    }

    private void SetTextDisplay(bool enable)
    {
        firstMinute.enabled = enable;
        secondMinute.enabled = enable;
        separator.enabled = enabled;
        firstSecond.enabled = enable;
        secondSecond.enabled = enabled;
    }
}
