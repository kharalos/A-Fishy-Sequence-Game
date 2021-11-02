using System;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class Controller : MonoBehaviour
{
    public static Controller Instance { get; protected set; }
    public Camera MainCamera;
    public Transform CameraPosition;
    public AudioSource footSource;
    public AudioClip[] clips;

    [Header("Control Settings")]
    public float MouseSensitivity = 100.0f;
    public float PlayerSpeed = 5.0f;
    public float RunningSpeed = 7.0f;
    public float JumpSpeed = 5.0f;
    
    float m_VerticalSpeed = 0.0f;
    bool m_IsPaused = false;
    
    float m_VerticalAngle, m_HorizontalAngle;
    public float Speed { get; private set; } = 0.0f;

    public bool LockControl { get; set; }

    public bool Grounded => m_Grounded;

    CharacterController m_CharacterController;

    bool m_Grounded;
    bool m_Crounching;
    float m_GroundedTimer;
    float m_SpeedAtJump = 0.0f;
    float oldHeight;


    [Header("Head Bobbing Settings")]
    public float walkingBobbingSpeed = 14f;
    public float bobbingAmount = 0.05f;

    float defaultPosY = 0;
    float timer = 0;
    int step;
    void Awake()
    {
        Instance = this;
    }
    
    void Start()
    {     
        m_IsPaused = false;
        m_Grounded = true;
        
        MainCamera.transform.SetParent(CameraPosition, false);
        MainCamera.transform.localPosition = Vector3.zero;
        MainCamera.transform.localRotation = Quaternion.identity;
        m_CharacterController = GetComponent<CharacterController>();
        oldHeight = m_CharacterController.height;

        m_VerticalAngle = 0.0f;
        m_HorizontalAngle = transform.localEulerAngles.y;
    }

    void Update()
    {
        bool wasGrounded = m_Grounded;
        bool loosedGrounding = false;
        
        if (!m_CharacterController.isGrounded)
        {
            if (m_Grounded)
            {
                m_GroundedTimer += Time.deltaTime;
                if (m_GroundedTimer >= 0.5f)
                {
                    loosedGrounding = true;
                    m_Grounded = false;
                }
            }
        }
        else
        {
            m_GroundedTimer = 0.0f;
            m_Grounded = true;
        }

        Speed = 0;
        Vector3 move = Vector3.zero;
        if (!LockControl)
        {
            // Jump (we do it first as 
            if (m_Grounded && Input.GetButtonDown("Jump"))
            {
                m_VerticalSpeed = JumpSpeed;
                m_Grounded = false;
                loosedGrounding = true;
            }


            
            bool running = Input.GetButton("Run");
            if (m_Crounching) running = false;
            float actualSpeed = running ? RunningSpeed : PlayerSpeed;

            // Crouch movement
            float height = m_CharacterController.height;
            float crouchedHeight = oldHeight / 2;
            if ((Input.GetKey(KeyCode.C)/* || Input.GetKey(KeyCode.LeftControl)*/) && !running)
            {
                height = Mathf.Lerp(height, crouchedHeight, .5f);
                m_CharacterController.height = height;
                m_Crounching = true;
            }
            else
            {
                height = Mathf.Lerp(height, oldHeight, .5f);
                m_CharacterController.height = height;
            }

            if (Input.GetKey(KeyCode.Mouse1))
            {
                MainCamera.fieldOfView = Mathf.Lerp(MainCamera.fieldOfView, 20, .5f);
            }
            else
            {
                MainCamera.fieldOfView = Mathf.Lerp(MainCamera.fieldOfView, 60, .5f);
            }

            if (loosedGrounding)
            {
                m_SpeedAtJump = actualSpeed;
            }

            // Move around with WASD
            move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
            if (move.sqrMagnitude > 1.0f)
                move.Normalize();

            float usedSpeed = m_Grounded ? actualSpeed : m_SpeedAtJump;
            
            move = move * usedSpeed * Time.deltaTime;
            
            move = transform.TransformDirection(move);
            m_CharacterController.Move(move);
            
            // Turn player
            float turnPlayer =  Input.GetAxis("Mouse X") * MouseSensitivity;
            m_HorizontalAngle = m_HorizontalAngle + turnPlayer;

            if (m_HorizontalAngle > 360) m_HorizontalAngle -= 360.0f;
            if (m_HorizontalAngle < 0) m_HorizontalAngle += 360.0f;
            
            Vector3 currentAngles = transform.localEulerAngles;
            currentAngles.y = m_HorizontalAngle;
            transform.localEulerAngles = currentAngles;

            // Camera look up/down
            var turnCam = -Input.GetAxis("Mouse Y");
            turnCam = turnCam * MouseSensitivity;
            m_VerticalAngle = Mathf.Clamp(turnCam + m_VerticalAngle, -89.0f, 89.0f);
            currentAngles = CameraPosition.transform.localEulerAngles;
            currentAngles.x = m_VerticalAngle;
            CameraPosition.transform.localEulerAngles = currentAngles;
  
            Speed = move.magnitude / (PlayerSpeed * Time.deltaTime);

            float actualBobSpeed;
            if (running) actualBobSpeed = walkingBobbingSpeed * (RunningSpeed / PlayerSpeed);
            else actualBobSpeed = walkingBobbingSpeed;

            //Bob Head
            if ((Mathf.Abs(Input.GetAxis("Horizontal")) > 0.1f || Mathf.Abs(Input.GetAxis("Vertical")) > 0.1f) && m_Grounded)
            {
                if (!footSource.isPlaying && MainCamera.transform.localPosition.y < -0.05f)
                {
                    step++;
                    if (step == 2) step = 0;
                    footSource.PlayOneShot(clips[step], m_CharacterController.velocity.magnitude / 5f);
                }

                //Player is moving
                timer += Time.deltaTime * actualBobSpeed;
                MainCamera.transform.localPosition = new Vector3(MainCamera.transform.localPosition.x, defaultPosY + Mathf.Sin(timer) * bobbingAmount, MainCamera.transform.localPosition.z);
            }
            else
            {
                //Idle
                timer = 0;
                MainCamera.transform.localPosition = new Vector3(MainCamera.transform.localPosition.x, Mathf.Lerp(MainCamera.transform.localPosition.y, defaultPosY, Time.deltaTime * walkingBobbingSpeed), MainCamera.transform.localPosition.z);
            }
        }

        // Fall down / gravity
        m_VerticalSpeed = m_VerticalSpeed - 10.0f * Time.deltaTime;
        if (m_VerticalSpeed < -10.0f)
            m_VerticalSpeed = -10.0f; // max fall speed
        var verticalMove = new Vector3(0, m_VerticalSpeed * Time.deltaTime, 0);
        var flag = m_CharacterController.Move(verticalMove);
        if ((flag & CollisionFlags.Below) != 0)
            m_VerticalSpeed = 0;
    }

    public void DisplayCursor(bool display)
    {
        m_IsPaused = display;
        Cursor.lockState = display ? CursorLockMode.None : CursorLockMode.Locked;
        Cursor.visible = display;
    }
}
