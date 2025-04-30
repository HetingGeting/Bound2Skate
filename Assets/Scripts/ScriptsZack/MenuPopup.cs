using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class MenuPopup : MonoBehaviour
{

    public Animator ShopPopup;
    public GameObject Shoppanelkanel;


    public void pressedTheUppBUtton () 
    {
        ShopPopup.SetBool("duFickUppDen", true);
    }

    public void kollahärTrycKTillbaka()
    {
        StartCoroutine(pressedTheBUttonInBack());
    }

    public IEnumerator pressedTheBUttonInBack()
    {
        ShopPopup.SetBool("duFickUppDen", false);
        yield return new WaitForSeconds(1f);
        Shoppanelkanel.SetActive(false);
    }




    public Animator MenuPopUp;
    public GameObject Nebypanelkanel;

    public void pressedTheMenuUppBUtton()
    {
        MenuPopUp.SetBool("DuFickUppDenHärMed", true);
    }

    public void MenykollahärTrycKTillbaka()
    {
        StartCoroutine(pressedTheMenuButtonInBack());
    }

    public IEnumerator pressedTheMenuButtonInBack()
    {
        MenuPopUp.SetBool("DuFickUppDenHärMed", false);
        yield return new WaitForSeconds(1f);
        Nebypanelkanel.SetActive(false);
    }


    

    public Animator TrickMenuPopUp;
    public GameObject TrickMenupanelkanel;
  
    public void pressedTheTrickMenuUppButton() 
    {
        TrickMenuPopUp.SetBool("DuFickUppDenHärOckså", true);
    }
  
    public void TrickMenykollahärTrycKTillbaka()
    {
        StartCoroutine(pressedTheTrickMenuButtonInBack());
    }
    
    public IEnumerator pressedTheTrickMenuButtonInBack()
    {
        TrickMenuPopUp.SetBool("DuFickUppDenHärOckså", false);
        yield return new WaitForSeconds(1f);
        TrickMenupanelkanel.SetActive(false);
    }
    
}
