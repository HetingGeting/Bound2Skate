using Microsoft.Win32.SafeHandles;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ZigmaSkateBoard : MonoBehaviour
{
    Rigidbody rb;
    bool ReadyToJump = true;
    public float jumpForce;
    public float jumpCooldown;
    
    float verticalInput;
    float horizontalInput;

    public Transform HjulFH, HjulFV, HjulBH, HjulBV;
    public Vector3 rotationBitch;
    public float goingSpeed = 2000f;
    public float stillSpeed = 0f;
    public WheelCollider hjulFH;
    public WheelCollider hjulFV;
    public WheelCollider hjulBH;
    public WheelCollider hjulBV;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Movement();
        MyInput();

    }
    void MyInput() 
    {

        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");

        if (Input.GetKey(KeyCode.Space) && ReadyToJump)
        {
            ReadyToJump = false;

            Invoke(nameof(ResetJump), jumpCooldown);
            Jump();
        }

    }

    void Movement() 
    {
        hjulFH.motorTorque = verticalInput * goingSpeed;
        hjulFV.motorTorque = verticalInput * goingSpeed;
        HjulFH.Rotate(hjulFH.rpm / 60 * 360 * Time.deltaTime, 0.0f, 0.0f);
        HjulFV.Rotate(hjulFV.rpm / 60 * 360 * Time.deltaTime, 0.0f, 0.0f);

        rb.AddForce(transform.right * horizontalInput * 1000f, ForceMode.Force);
    }

    void ResetJump()
    {
        ReadyToJump = true;
    }
    void Jump()
    {
        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }
}
