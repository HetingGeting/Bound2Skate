using System.Collections;
using System.Collections.Generic;
using UnityEditor.EditorTools;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject RaceConversationPanel;
    public GameObject MoneyMenuButton;
    public GameObject TutorialPanel;

    public static bool Talking = false;
    public static int money;
    public static bool Race = false;

    void Start()
    {
        TutorialPanel.SetActive(true);
        money = 600;
    }

    void Update()
    {
        if (Talking && !Race && Input.GetKeyDown(KeyCode.H))
        {
            RaceConversationPanel.SetActive(true);
            MoneyMenuButton.SetActive(false);

            Talking = false;
        }
    }
}
