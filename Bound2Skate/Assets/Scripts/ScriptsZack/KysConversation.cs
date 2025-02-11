using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KysConversation : MonoBehaviour
{

    void Update()
    {
        if (GameManager.Race && transform.position == new Vector3(1.59000003f, 1.56470001f, -17.3400002f)) 
        {
            Destroy(gameObject);
        }
    }
}
