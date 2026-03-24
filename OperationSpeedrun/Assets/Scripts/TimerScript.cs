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
    public float fastTime;
    [SerializeField]
    public float previousTime;

    bool isRunning = false;

    // Update is called once per frame
    void Update()
    {
        if (isRunning)
        {
            time += Time.deltaTime;

            timerText.text = time.ToString();
        }


        if (time < fastTime)
        {
            fastTime = time;
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
        
        if (time < fastTime)
        {
            fastTime = time;
        }
        else
        {
            previousTime = time;
        }

        
    }
}
