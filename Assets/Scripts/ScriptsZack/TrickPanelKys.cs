using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrickPanelKys : MonoBehaviour
{
    // Start is called before the first frame update

    public Text TrickPoints;
    public Text TrickName;
    public Text TrickMult;
    public Text TrickNameShader;
    void Awake()
    {
        GameManager.TrickPoints = TrickPoints;
        GameManager.TrickName = TrickName;
        GameManager.TrickName = TrickNameShader; 
        GameManager.ScoreMultiplier = TrickMult;
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.CalcIsActive) 
        {
            Destroy(gameObject);
        }
    }
}
