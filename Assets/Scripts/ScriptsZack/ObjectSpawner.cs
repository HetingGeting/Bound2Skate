using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject[] Trash;

    public GameObject Trashcan;
    public GameObject Particles;
    void Start()
    {
        for (int i = 0; i < Trash.Length; i++) 
        {
            Instantiate(Trash[i], Trash[i].transform.position, Trash[i].transform.rotation);
        }
    }

    private void Update()
    {
        if (Kys.Bought1 && !GameManager.Spawned1) 
        {
            Instantiate(Particles, Trash[0].transform.position, Particles.transform.rotation);
            GameManager.Spawned1 = true;
        }

        if (Kys2.Bought2 && !GameManager.Spawned2)
        {
            Instantiate(Particles, Trash[1].transform.position, Particles.transform.rotation);
            GameManager.Spawned2 = true;
        }

        if (Kys.Bought1 && Kys2.Bought2 && !GameManager.Spawned3)
        {
            Instantiate(Trashcan, Trashcan.transform.position, Trashcan.transform.rotation);
            GameManager.Spawned3 = true;
        }
    }

}
