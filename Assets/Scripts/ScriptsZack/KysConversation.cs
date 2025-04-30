using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KysConversation : MonoBehaviour
{

    void Update()
    {
        if (GameManager.Race && transform.position == new Vector3(1.21000004f, 1.60000002f, -1.29999995f)) 
        {
            Destroy(gameObject);
        }
    }
}
