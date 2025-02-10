using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kys2 : MonoBehaviour
{
    public static bool Bought2 = false;
    void Update()
    {
        if (Bought2 && transform.position == new Vector3(-3.00305796f, 1.24109936f, -14.3672667f))
        {
            Destroy(gameObject);
        }
    }
}
