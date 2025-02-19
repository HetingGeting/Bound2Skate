using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneScript : MonoBehaviour
{
    bool CameraViewEtt = true;
    bool CameraViewTvå = true;
    bool CameraViewTre = true;
    public GameObject PlayerModel;
    void Update()
    {
        if (GameManager.Race) 
        {
            if(RaceUI.CountdownTime > 4 && RaceUI.CountdownTime < 5)
            {
                if (CameraViewEtt)
                {
                    CameraViewOne();
                    CameraViewEtt = false;
                }
                CameraMovement(Vector3.right, 0.2f);
            }
           

            if (RaceUI.CountdownTime <= 4 && RaceUI.CountdownTime >= 2.5) 
            {
                if (CameraViewTvå)
                {
                    CameraViewTwo();
                    CameraViewTvå = false;
                }
                CameraMovement(Vector3.up, 0.09f);
            }

            if (RaceUI.CountdownTime <= 2.5) 
            {
                if (CameraViewTre) 
                {
                    CameraViewThree();
                    CameraViewTre = false;
                }
                CameraMovement(Vector3.down, 1.33f);
            }
        }           
    }
    void CameraViewOne() 
    {
        transform.position = PlayerModel.transform.position + new Vector3(0.980000019f, 0.639999986f, 1.01999998f);
        transform.rotation = new Quaternion(0, 1f, 0, 0);
        return;
    }

    void CameraViewTwo()
    {
        transform.position = PlayerModel.transform.position + new Vector3(0.439999998f, 0, -0.49000001f);
        transform.rotation = new Quaternion(0, -0.397063911f, 0, 0.917791009f);
        return;
    }


    void CameraViewThree()
    {
        transform.position = PlayerModel.transform.position + new Vector3(-0.0030000899f, 16.2999992f, -3.16810942f);
        transform.rotation = new Quaternion(0, 0, 0, 0);
        return;
    }

    void CameraMovement(Vector3 direction, float movementmult)
    {
        for (int i = 0; i <= 4; i++)
        {
            transform.Translate(direction * Time.deltaTime * movementmult);
        }
    }
}
