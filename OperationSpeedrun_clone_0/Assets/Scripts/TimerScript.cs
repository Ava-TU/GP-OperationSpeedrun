using UnityEngine;
using TMPro;

public class TimerScript : MonoBehaviour
{
    [SerializeField]
    TMP_Text timerText;

    [SerializeField]
    float time;

    public float startTimer = 0;

    [SerializeField]
    public float bestTime;
    [SerializeField]
    public float previousTime;

    bool isRunning = false;

    void Start()
    {
        previousTime = 0;
        bestTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (isRunning)
        {
            time += Time.deltaTime;

            timerText.text = time.ToString();
        }

        
    }

    public void StartTimer()
    {
        isRunning = true;

        time = 0;
    }

    public void StopTimer()
    {
        isRunning = false;

        previousTime = time;
        
        if (time < bestTime)
        {
            bestTime = time;
        }
        if (bestTime == 0)
        {
            bestTime = previousTime;
        }
        
    }
}
