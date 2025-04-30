using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtonCode : MonoBehaviour
{
    public void StartButton() 
    {
        SceneManager.LoadScene("Zack Skateboard movement", LoadSceneMode.Single);
    }
}
