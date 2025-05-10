using TMPro;
using UnityEngine;

public class TimerManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;
    public float timer { get; private set; }
    public bool isRunning;

    [Header("DEBUG")]
    public float maxLimitsTime = 60.0f;
    public bool HasTimerExceeded(float timeLimits) => timer >= timeLimits;

    public void Update()
    {
        if (isRunning)
        {
            timer += Time.deltaTime;

            int minutes = Mathf.FloorToInt(timer / 60);
            int seconds = Mathf.FloorToInt(timer % 60);
            int milliseconds = Mathf.FloorToInt((timer * 1000f) % 1000f);
            timerText.text = string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, milliseconds);

            if (timer > maxLimitsTime)
            {
                print("You loose");
                //callLooseFunction;
                ResetTimer();
            }
        }
    }
    public void ResetTimer()
    {
        timer = 0;
        isRunning = false;
        timerText.text = "01:00:000";
    }
    public void AddTime(float time)
    {
        timer = Mathf.Clamp(timer + time, 0, 60);
    }
}
