using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KysConversation : MonoBehaviour
{

    void Update()
    {
        if (GameManager.Race && transform.position == new Vector3(-3.1500001f, 1.82000005f, -17.5699997f)) 
        {
            Destroy(gameObject);
        }
    }
}
