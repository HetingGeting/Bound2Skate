using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoversationScript : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        GameManager.Talking = true;
    }

}
