using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.EditorTools;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject RaceConversationPanel;
    public GameObject MoneyMenuButton;
    public GameObject TutorialPanel;
    public GameObject MenuButton;
    public GameObject SkatingPlayer;
    public GameObject WalkingPlayer;
    public GameObject TrickyPanel;

    private Text MoneyDisplayer;
    private Text MoneyDisplayerOutline;
    private Text ScoreDisplayer;
    private Text ScoreDisplayerOutline;
    public static Text TrickPoints;
    public static Text ScoreMultiplier;
    public static Text TrickName;

    private Camera PlayerCamera;
    private Camera CutsceneCamera;

    private CinemachineFreeLook CameraController;

    private Button MenuButtonExit;
    private Button ShopButtonExit;
    private Button ConversationButtonExit1;
    private Button ConversationButtonExit2;
    private Button MenuButtonStart;
    private Button ShopButtonStart;

    public static Transform railpointA;
    public static Transform railpointB;

    public static bool Talking = false;
    public static bool Race = false;
    public static bool Kickflip;
    public static bool ShoveIt;
    
    public static bool Spawned1;
    public static bool Spawned2;
    public static bool Spawned3;

    public CinemachineVirtualCamera camCum;

    public static int money;
    private int tempmult;
    private int CalculatedScore;
    private int DisplayScore;
    private int mult;
    private int smallScore;

    public static bool CalcIsActive;
    bool ReadyToTalk = true;

    bool PlayerSpawned;
    float TrickPanelTimer;
    public static bool Changable;

    void Start()
    {
        Instantiate(WalkingPlayer, new Vector3(-0.930000007f, 5f, -1.57599998f), new Quaternion(0, 0, 0, 0));

        //TutorialPanel.SetActive(true);
        money = 600;
        MoneyDisplayer = transform.Find("UIManager").Find("MoneyPanel").Find("MoneyText").GetComponent<Text>();
        MoneyDisplayerOutline = transform.Find("UIManager").Find("MoneyPanel").Find("MoneyOutline").GetComponent<Text>();
        ScoreDisplayer = transform.Find("UIManager").Find("ScorePanel").Find("ScorePanelMainText").GetComponent<Text>();
        ScoreDisplayerOutline = transform.Find("UIManager").Find("ScorePanel").Find("ScorePanelOutlineText").GetComponent<Text>(); 
       // CameraController = transform.Find("CM FreeLook1").GetComponent<CinemachineFreeLook>();
        MenuButtonExit = transform.Find("UIManager").Find("MenuPanel").Find("MenuExitButton").GetComponent<Button>();
        ShopButtonExit = transform.Find("UIManager").Find("ShopPanel").Find("ShopExitButton").GetComponent<Button>();
        ConversationButtonExit1 = transform.Find("UIManager").Find("RaceConversationPanel").Find("ConversationExitButtonYes").GetComponent<Button>();
        ConversationButtonExit2 = transform.Find("UIManager").Find("RaceConversationPanel").Find("ConversationExitButtonNo").GetComponent<Button>();
        MenuButtonStart = transform.Find("UIManager").Find("MenuButton").GetComponent<Button>();
        ShopButtonStart = transform.Find("UIManager").Find("ShopButton").GetComponent<Button>();
        railpointA = transform.Find("RailPointA").GetComponent<Transform>();
        railpointB = transform.Find("RailPointB").GetComponent<Transform>();

        MenuButtonExit.onClick.AddListener(OutOfMenu);
        ShopButtonExit.onClick.AddListener(OutOfMenu);
        ConversationButtonExit1.onClick.AddListener(OutOfMenu);
        ConversationButtonExit2.onClick.AddListener(OutOfMenu);
        MenuButtonStart.onClick.AddListener(InMenu);
        ShopButtonStart.onClick.AddListener(InMenu);


    }

    void Update()
    {
        //camCum.LookAt = transform.Find("PlayerCameraRoot");
        //camCum.Follow.gameObject.scene.

        UIDisplayText();

        if (Talking && !Race && ReadyToTalk)
        { 
            ControllConversation(); 
        }

        if (Race) 
        { 
            RaceControllPlayer(); 
        }

        if (Kickflip)
        {
            TrickPanelTimer += 3f;

            if (!CalcIsActive) 
            {
                GameObject trickyPanel = Instantiate(TrickyPanel, TrickyPanel.transform.position, TrickyPanel.transform.rotation); 
            }
            
            ShowPointCalc("Kickflip", 300, 1);
        }

        if (ShoveIt) 
        {
            TrickPanelTimer += 3f;

            if (!CalcIsActive) 
            {
                GameObject trickyPanel = Instantiate(TrickyPanel, TrickyPanel.transform.position, TrickyPanel.transform.rotation);
            }

            ShowPointCalc("Shove it", 150, 1);
        }

 

        if (TrickPanelTimer > 0)
        {
            TrickPanelTimer -= Time.deltaTime;
        }
        else 
        { 
            TrickTimerDone(); 
        }
    }
    void ControllConversation() 
    {
        RaceConversationPanel.SetActive(true);
        MoneyMenuButton.SetActive(false);
        MenuButton.SetActive(false);

        Talking = false;
        ReadyToTalk = false;
        Invoke(nameof(WaitASecondMan), 10);

        InMenu();
        CutscenePlaying();
    }

    void RaceControllPlayer()
    {
        if (!PlayerSpawned) { SpawnPlayer(); }
        ChangeCameraCutscene();
        CutscenePlaying();
        if (RaceUI.CountdownTime <= 0)
        {
            CutsceneEnd();
            OutOfMenu();
        }
    }

    void WaitASecondMan() 
    {
        ReadyToTalk = true;
    }

    void UIDisplayText() 
    {
        MoneyDisplayer.text = money + " kr";
        MoneyDisplayerOutline.text = money + " kr";

        ScoreDisplayer.text = DisplayScore.ToString();
        ScoreDisplayerOutline.text = DisplayScore.ToString();
    }

    void SpawnPlayer()
    {
        Instantiate(SkatingPlayer, new Vector3(-2f, 1.5f, -22.5f), new Quaternion(0, 0, 0, 0));
        PlayerCamera = transform.Find("Skateboard").Find("PlayerCamera").GetComponent<Camera>();
        CutsceneCamera = transform.Find("Skateboard").Find("Skateboard 1").Find("CutsceneCamera").GetComponent<Camera>();
        PlayerSpawned = true;
    }
    void ChangeCameraCutscene() 
    {
        PlayerCamera.gameObject.SetActive(false);
        CutsceneCamera.gameObject.SetActive(true);
    }
    
    void ChangeCameraPlayer()
    {
        CutsceneCamera.gameObject.SetActive(false);
        PlayerCamera.gameObject.SetActive(true);
    }
    
    void CutscenePlaying()
    {
        ExtremtZigmaSkateboard.isBreaking = true;
    }
    
    void CutsceneEnd() 
    {
        ChangeCameraPlayer();
    }

    void InMenu() 
    {
        CameraController.enabled = false;
    }

    void OutOfMenu()
    {
        CameraController.enabled = true;
        ExtremtZigmaSkateboard.isBreaking = false;
    }


    void ShowPointCalc(string trickname, float trickpoints, float tempmult)
    {
        CalcIsActive = true;

        TrickName.text = trickname;

        smallScore += (int)trickpoints;

        TrickPoints.text = smallScore.ToString();

        mult += (int)tempmult;

        ScoreMultiplier.text = mult.ToString();

        CalculatedScore = (int)(smallScore * mult);

        Kickflip = false;
        ShoveIt = false;
    }

    void TrickTimerDone() 
    {
        DisplayScore += CalculatedScore;
        CalcIsActive = false;
        mult = 0;
        CalculatedScore = 0; 
    }
    public static IEnumerator PlayerCanChange()
    {
        yield return new WaitForSeconds(1f);
        Changable = true;
    }

}
