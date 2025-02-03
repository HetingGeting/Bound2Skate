using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class RaceUI : MonoBehaviour
{
    public float totalTime = 180;
    public float CountdownTime = 5;
    float CountdownSeconds;
    public Text TimerText;
    public Text CountdownText;



    void Update()
    {
        if (CountdownTime > 0)
        {
            GameManager.Race = true;
            CountdownText.text = "" + CountdownSeconds;
            CountdownTime -= Time.deltaTime;
            CountdownSeconds = Mathf.Round(CountdownTime);

        }
        else
        {
            CountdownText.text = "";

            if (totalTime > 0)
            {
                
                totalTime -= Time.deltaTime;
                float Minutes = Mathf.FloorToInt(totalTime / 60);
                float Seconds = Mathf.FloorToInt(totalTime % 60);


                TimerText.text = string.Format("{0:00} : {1:00}", Minutes, Seconds);
            }
            else
            {
                totalTime = 0;
                GameManager.Race = false;
            }
        }
    }
}
