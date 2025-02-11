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
    }

    public void DifferentTexts() 
    {
        if (textWriterSingle != null && textWriterSingle.IsActive()) 
        { //Currently active textwriter
            textWriterSingle.WriteAllAnddestroy();
        } else {
        string[] messageArray = new string[] {
                "I found this cool skatepark that seems to be abandoned",
                "Skate around by pressing WASD",
                "Try to do a trick by jumping with space and pressing A or D in the Air",
                "WOW! you did a kickflip! different tricks give different scores",
                "Try to get a score of 500!"

        };
        string message = messageArray[UnityEngine.Random.Range(0,messageArray.Length)];
            StartTalkingSound();
        textWriterSingle = TempTextWriterScript.AddWriter_Static(text, message, .1f, true, true, StopTalkingSound);
        textWriterSingle = TempTextWriterScript.AddWriter_Static(OutlineText, message, .1f, true, true, StopTalkingSound);
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
