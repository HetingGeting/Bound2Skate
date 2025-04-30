using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;
using UnityEngine.UIElements;

public class CPGain : MonoBehaviour
{

    public int crowdPoints;
    public int CPStreakScore;
    public bool streakActive;
    float timeSinceTrick; //TimeLeft
    public static bool TrickCompleted;

    public int TrickInStreakCounter;

    public float MaxStreakTime;

    public bool StreakTimerOn;


    void Start()
    {
        crowdPoints = 0;
        TrickCompleted = false;
        StreakTimerOn = false;
        MaxStreakTime = 6;
    }

    // Update is called once per frame
    void Update()
    {
        checkStreak();
        StreakTimer();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TrickCompleted = true;
        }

        print(TrickInStreakCounter);
        
        if (!streakActive)
        {
            crowdPoints = crowdPoints + CPStreakScore;
        }
       
        if (TrickCompleted == true)
        {
            timeSinceTrick = 0;
            TrickInStreakCounter += 1;
            TrickCompleted = false;

            if (streakActive == false)
            { streakActive = true; }
        }
    }


    void checkStreak()
    {
        if (timeSinceTrick < 6)
        {
            streakActive = true;
        }
        else
        {
            streakActive = false;
        }
    }

    void TrickStatus()
    {
        //if sats som kollar om ett trick görs

        //streak koll (ingen streak -> ny streak) ( streak aktiv -> Bygg vidare på streak)
    }


    IEnumerator StreakTimer()
    {
        if (streakActive)
        {
            yield return new WaitForSeconds(MaxStreakTime);
                if (timeSinceTrick >= MaxStreakTime)
            {
                streakActive = false;
            }
                else
            {
                streakActive = true;
                TrickInStreakCounter = 0;
            }
        }
    }

    void GiveStreakPoints()
    { 
        
    }


}
