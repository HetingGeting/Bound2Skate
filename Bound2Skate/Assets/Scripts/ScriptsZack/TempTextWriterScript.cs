using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static TempTextWriterScript;
public class TempTextWriterScript : MonoBehaviour
{
    // Tutorial för självskrivande text
    // Kolla ifall errors 
    // https://www.youtube.com/watch?v=ZVh4nH8Mayg

    private static TempTextWriterScript instance;
    
    private List<TextWriterSingle> textWriterSingleList;
    private void Awake()
    {
        instance = this;
        textWriterSingleList = new List<TextWriterSingle>(); 
    }
    public static TextWriterSingle AddWriter_Static(Text uiText, string textToWrite, float timePerCharacter, bool InvisibleCharacters, bool removeWriterBeforeAdd, Action onComplete)
    {
        if (removeWriterBeforeAdd)
        {
            instance.RemoveWriter(uiText);
        }
        return instance.AddWriter(uiText, textToWrite, timePerCharacter, InvisibleCharacters, onComplete);
    }
    private TextWriterSingle AddWriter(Text uiText, string textToWrite, float timePerCharacter, bool InvisibleCharacters, Action onComplete) 
    {
        TextWriterSingle textWriterSingle = new TextWriterSingle(uiText, textToWrite, timePerCharacter, InvisibleCharacters, onComplete);
        textWriterSingleList.Add(textWriterSingle);
        return textWriterSingle;
    }
    public static void RemoveWriter_Static(Text uiText) 
    {
        instance.RemoveWriter(uiText);
    }
    private void RemoveWriter(Text uiText) 
    {
        for (int i = 0; i < textWriterSingleList.Count; i++)
        {
            if (textWriterSingleList[i].GetUIText() == uiText) 
            {
                textWriterSingleList.RemoveAt(i);
                i--;
            }
        }
    }

    private void Update()
    {
        for (int i = 0; i < textWriterSingleList.Count; i++) 
        {
            bool destroyInstance = textWriterSingleList[i].Update();
            if (destroyInstance)
            {
                textWriterSingleList.RemoveAt(i);
                i--;
            }
        }
    }
    // är en textwriter instance
    public class TextWriterSingle 
    {
        private Text uiText;
        private string textToWrite;
        private float timePerCharacter;
        private float timer;
        private int characterIndex;
        private bool InvisibleCharacters;
        private Action onComplete;
        public TextWriterSingle(Text uiText, string textToWrite, float timePerCharacter, bool InvisibleCharacters, Action onComplete)
        {
            this.uiText = uiText;
            this.textToWrite = textToWrite;
            this.timePerCharacter = timePerCharacter;
            this.InvisibleCharacters = InvisibleCharacters;
            this.onComplete = onComplete;
            characterIndex = 0;

        } 


        // Blir true ifall klar
        public bool Update()
        {
                timer -= Time.deltaTime;
                while (timer <= 0f)
                {
                    // Visa nästa bokstav
                    timer += timePerCharacter;
                    characterIndex++;
                    string text2 = textToWrite.Substring(0, characterIndex);
                    if (InvisibleCharacters)
                    {
                        text2 += "<color=#00000000>" + textToWrite.Substring(characterIndex) + "</color>";
                    }
                    uiText.text = text2;

                    if (characterIndex >= textToWrite.Length)
                    {
                    // Hela texten visas
                    if (onComplete != null) onComplete();
                        return true;
                    }
                }

            return false;
            
        }

        public Text GetUIText() 
        {
            return uiText;
        }

        public bool IsActive() 
        {
            return characterIndex < textToWrite.Length;
        }

        public void WriteAllAnddestroy() 
        { 
            uiText.text = textToWrite;
            characterIndex = textToWrite.Length;
                if (onComplete != null) onComplete();
            TempTextWriterScript.RemoveWriter_Static(uiText);
        }
    }
}
