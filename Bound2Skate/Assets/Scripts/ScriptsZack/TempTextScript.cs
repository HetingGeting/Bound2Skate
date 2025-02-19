using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class TempTextScript : MonoBehaviour
{
    private Text text;
    private Button textbutton;
    private TempTextWriterScript.TextWriterSingle textWriterSingle;
    private AudioSource talkingAudioSource;
    private Text OutlineText;
    public GameObject TutorialPanel;


    int i = 0;
    private void Awake()
    {
        OutlineText = transform.Find("TutorialPanel").Find("OutlineText").GetComponent<Text>();
        text = transform.Find("TutorialPanel").Find("messageText").GetComponent<Text>();
        textbutton = transform.Find("TutorialPanel").Find("TextButton").GetComponent<Button>();
        talkingAudioSource = transform.Find("TalkingSoundEffekt").GetComponent<AudioSource>();
    }
    void Start()
    {
        textbutton.onClick.AddListener(DifferentTexts);
        DifferentTexts();
    }

    public void DifferentTexts() 
    {
        if (textWriterSingle != null && textWriterSingle.IsActive()) 
        { //Currently active textwriter
            // textWriterSingle.WriteAllAnddestroy();
        } else {
        string[] messageArray = new string[] {
                "Skate around by pressing WASD",
                "Try to do a trick by jumping with space and pressing A or D in the Air",
                "You can build a combo by doing multiple tricks in a row",
                "Go and talk to Alex to start a Race"
        };
            if(i >= 3) 
            {
                TutorialPanel.SetActive(false);
                StopTalkingSound();
            }
            else 
            {
                string message = messageArray[i];
                StartTalkingSound();
                textWriterSingle = TempTextWriterScript.AddWriter_Static(text, message, .05f, true, true, StopTalkingSound);
                textWriterSingle = TempTextWriterScript.AddWriter_Static(OutlineText, message, .05f, true, true, StopTalkingSound);

                i++;

            }

        }
    }

    private void StartTalkingSound()
    {
        talkingAudioSource.Play();
    }

    private void StopTalkingSound()
    {
        talkingAudioSource.Stop();
    }
}
