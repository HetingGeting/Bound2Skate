using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Button DestroyTrashButton1;
    public Button DestroyTrashButton2;
    private void Start()
    {
        DestroyTrashButton1.onClick.AddListener(Paramater1);

        DestroyTrashButton2.onClick.AddListener(Paramater2);
    }
    public void Paramater1() 
    {
        if (GameManager.money >= 250 && !Kys.Bought1)
        {
            Kys.Bought1 = true;

            GameManager.money -= 250;
        }
    }

    public void Paramater2()
    {
        if (GameManager.money >= 350 && !Kys2.Bought2)
        {
            Kys2.Bought2 = true;

            GameManager.money -= 350;
        }
    }

}
