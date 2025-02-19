using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtremtZigmaSkateboard : MonoBehaviour
{
    private float horizontalInput, verticalInput;
    private float currentSteerAngle, currentbreakForce;
    public static bool isBreaking;
    public Animator weezyfBabyAnim;
    private Rigidbody rb;

    public float playerHeight;
    public LayerMask whatIsGround;
    public LayerMask ConversationGround;
    public bool grounded;
    public float jumpForce;
    public float jumpCooldown;
    bool ReadyToJump = true;

    public static bool conversationgrounded;

    bool animationActive;
    int KickflipAnimationTimer = 1;

    // Settings
    [SerializeField] private float motorForce, breakForce, maxSteerAngle;

    // Wheel Colliders som vi ska ha bak och fram
    [SerializeField] private WheelCollider frontLeftWheelCollider, frontRightWheelCollider;
    [SerializeField] private WheelCollider rearLeftWheelCollider, rearRightWheelCollider;

    // Wheels
    [SerializeField] private Transform frontLeftWheelTransform, frontRightWheelTransform;
    [SerializeField] private Transform rearLeftWheelTransform, rearRightWheelTransform;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        GetInput();
        HandleMotor();
        HandleSteering();
        UpdateWheels();
    }

    private void Update()
    {
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.3f, whatIsGround);


        conversationgrounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, ConversationGround);

        if (Input.GetKey(KeyCode.W))
        {
            weezyfBabyAnim.SetBool("IsSkating", true);
        }
        else
        {
            weezyfBabyAnim.SetBool("IsSkating", false);
        }

        if (Input.GetKey(KeyCode.Space) && ReadyToJump && grounded)
        {
            ReadyToJump = false;

            Jump();

            Invoke(nameof(ResetJump), jumpCooldown);
        }

        if(conversationgrounded) 
        {
            GameManager.Talking = true;
        }

        if (!grounded && !animationActive && (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))) 
        {
            GameManager.Kickflip = true;
            Animation();
        }
    }

    private void GetInput()
    {
        // Steering Input
        horizontalInput = Input.GetAxis("Horizontal");

        // Acceleration Input
        verticalInput = Input.GetAxis("Vertical");
    }

    private void HandleMotor()
    {
        frontLeftWheelCollider.motorTorque = verticalInput * motorForce;
        frontRightWheelCollider.motorTorque = verticalInput * motorForce;
        currentbreakForce = isBreaking ? breakForce : 0f;
        ApplyBreaking();
    }

    private void ApplyBreaking()
    {
        frontRightWheelCollider.brakeTorque = currentbreakForce;
        frontLeftWheelCollider.brakeTorque = currentbreakForce;
        rearLeftWheelCollider.brakeTorque = currentbreakForce;
        rearRightWheelCollider.brakeTorque = currentbreakForce;
    }
    

    private void HandleSteering()
    {
        currentSteerAngle = maxSteerAngle * horizontalInput;
        frontLeftWheelCollider.steerAngle = currentSteerAngle;
        frontRightWheelCollider.steerAngle = currentSteerAngle;
    }

    private void UpdateWheels()
    {
        UpdateSingleWheel(frontLeftWheelCollider, frontLeftWheelTransform);
        UpdateSingleWheel(frontRightWheelCollider, frontRightWheelTransform);
        UpdateSingleWheel(rearRightWheelCollider, rearRightWheelTransform);
        UpdateSingleWheel(rearLeftWheelCollider, rearLeftWheelTransform);
    }

    private void UpdateSingleWheel(WheelCollider wheelCollider, Transform wheelTransform)
    {
        wheelTransform.rotation = Quaternion.identity;
        Vector3 pos;
        Quaternion rot;
        wheelCollider.GetWorldPose(out pos, out rot);
        wheelTransform.rotation = rot;
        wheelTransform.position = pos;
    }
    private void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }
    private void ResetJump()
    {
        ReadyToJump = true;
    }

    void Animation() 
    {
        animationActive = true;
        Invoke(nameof(AnimationSetActive), KickflipAnimationTimer);
    }

    void AnimationSetActive() 
    {
        animationActive = false;
    }
}