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
    public LayerMask GrindableSurface;
    public bool grounded;
    public bool CanGrind;
    public float jumpForce;
    public float jumpCooldown;
    bool ReadyToJump = true;

    public static bool conversationgrounded;
    bool animationActive;
    float KickflipAnimationTimer = 1;
    float ShoveItAnimationTimer = 1;


    public float GrindSpeed = 0.6f;
    public float closeDistance = 0.2f;

    public bool Changable;

    public GameObject WalkingPlayer;

    public bool Kolla;
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
        GrindMasterDX();
        CheckPlayer();
    }

    private void Update()
    {
        if (GameManager.Changable) { Kolla = true; } else { Kolla = false; }

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
            Animation(KickflipAnimationTimer);
        }

        if (!grounded && !animationActive && (Input.GetKey(KeyCode.S)))
        {
            GameManager.ShoveIt = true;
            Animation(ShoveItAnimationTimer);
        }


        if (Input.GetKey(KeyCode.F) && GameManager.Changable)
        {
            StartCoroutine(GameManager.PlayerCanChange());
            GameManager.Changable = false;
            StartWalking();
        }
    }

    void StartWalking()
    {
        Instantiate(WalkingPlayer, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    private void CheckPlayer() 
    {
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.3f, whatIsGround);
        CanGrind = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.3f, GrindableSurface);
        conversationgrounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, ConversationGround);
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
        frontLeftWheelCollider.motorTorque = verticalInput * motorForce * 10f;
        frontRightWheelCollider.motorTorque = verticalInput * motorForce * 10f;
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
    void Animation(float AnimationTimer) 
    {
        animationActive = true;
        Invoke(nameof(AnimationSetActive), AnimationTimer);
    }
    void AnimationSetActive() 
    {
        animationActive = false;
    }

    void GrindMasterDX()
    {/*
        if (GameManager.railpointA) 
        {
            Vector3 offset = GameManager.railpointA.position - transform.position;

            float sqrLen = offset.sqrMagnitude;

            if(sqrLen < closeDistance * closeDistance) 
            {
                transform.position = Vector3.MoveTowards(GameManager.railpointA.position + new Vector3(0f,0.2f,0f), GameManager.railpointB.position + new Vector3(0f, 0.2f, 0f), GrindSpeed * Time.fixedDeltaTime);
            }
        }
        */
    }
}