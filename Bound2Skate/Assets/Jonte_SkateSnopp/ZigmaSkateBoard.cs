using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class ZigmaSkateBoard : MonoBehaviour
{
    public Transform HjulFH, HjulFV, HjulBH, HjulBV;
    public Rigidbody rb;
    public Animator weezyfBabyAnim;
    public Animator boardAnim;
    public float goingSpeed = 2000f;
    public float stillSpeed = 0f;
    public WheelCollider hjulFH;
    public WheelCollider hjulFV;
    public WheelCollider hjulBH;
    public WheelCollider hjulBV;
    public float amount = 50f;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            hjulFH.motorTorque = Input.GetAxis("Vertical") * goingSpeed;
            hjulFV.motorTorque = Input.GetAxis("Vertical") * goingSpeed;
            HjulFH.Rotate(hjulFH.rpm / 60 * 360 * Time.deltaTime, 0.0f, 0.0f);
            HjulFV.Rotate(hjulFV.rpm / 60 * 360 * Time.deltaTime, 0.0f, 0.0f);
            HjulBH.Rotate(hjulBH.rpm / 60 * 360 * Time.deltaTime, 0.0f, 0.0f);
            HjulBV.Rotate(hjulBV.rpm / 60 * 360 * Time.deltaTime, 0.0f, 0.0f);

            weezyfBabyAnim.SetBool("IsSkating", true);
        }
        else 
        {
            hjulFH.motorTorque = Input.GetAxis("Vertical") * stillSpeed;
            hjulFV.motorTorque = Input.GetAxis("Vertical") * stillSpeed;
            weezyfBabyAnim.SetBool("IsSkating", false);
        }

        if (Input.GetKey(KeyCode.A))
        {
            boardAnim.SetBool("isRighting", true);
        }
        else
        {
            boardAnim.SetBool("isRighting", false);
        }

        if (Input.GetKey(KeyCode.D))
        {
            boardAnim.SetBool("isLefting", true);
        }
        else
        {
            boardAnim.SetBool("isLefting", false);
        }

        //float h = Input.GetAxis("Horizontal") * -amount * Time.deltaTime;
        //rb.AddTorque(transform.up * h, ForceMode.VelocityChange);
    }
}
