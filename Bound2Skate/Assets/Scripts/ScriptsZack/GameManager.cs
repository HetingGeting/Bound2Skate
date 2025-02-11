using System.Collections;
using System.Collections.Generic;
using UnityEditor.EditorTools;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public GameObject RaceConversationPanel;
    public GameObject MoneyMenuButton;
    public GameObject TutorialPanel;
    public GameObject MenuButton;

    public Text MoneyDisplayer;

    public static bool Talking = false;
    public static int money;
    public static bool Race = false;

    public static bool Spawned1;
    public static bool Spawned2;
    public static bool Spawned3;
    void Start()
    {
        //TutorialPanel.SetActive(true);
        money = 600;
    }

    void Update()
    {
        if (Talking && !Race && Input.GetKeyDown(KeyCode.H))
        {
            RaceConversationPanel.SetActive(true);
            MoneyMenuButton.SetActive(false);
            MenuButton.SetActive(false);

            Talking = false;
        }

        MoneyDisplayer.text = "Money: " + money;
    }
}
