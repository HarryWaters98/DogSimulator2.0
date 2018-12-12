using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Main;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]
[RequireComponent(typeof(Animator))]
public class DogCharacterController : MonoBehaviour
{
    [SerializeField] AudioClip m_audioClip;
    private Animator m_animator;
    private Rigidbody m_rigidbody;

    private Quaternion m_rotation;
    private Vector3 m_rotationVelocity;
    private float m_rotationSpeed;
    private float m_rotationDefaultSpeed = 180f;
    private float m_horizontal;
    private float m_vertical;
   
    private float m_walkingSpeed = 40f;
    private float m_runningSpeed = 100f;
    private bool m_isWalking;
    private bool m_isRunning;
    private bool m_triggerJump;
    public bool m_triggerBark;
    private AudioSource m_audioSourse;

    
    void Start()
    {
        m_animator = GetComponent<Animator>();
        m_rigidbody = GetComponent<Rigidbody>();
        m_audioSourse = GetComponent<AudioSource>();
        m_rigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
    }

    
    void Update()
    {
        Getinput();
        Move();
        UpdateAnimator();
    }

    
    private void Getinput()
    {
        m_isWalking = false;
        m_isRunning = false;
        m_horizontal = Input.GetAxis(AxisNames.Horizontal);
        m_vertical = Input.GetAxis(AxisNames.Vertical);

        // Character controls
        m_isWalking = (m_vertical > 0f) || (m_horizontal != 0f);
        m_isRunning = (m_vertical > 0f) && Input.GetKey(KeyCode.Mouse0);
        m_rotationSpeed = (m_horizontal > 0f) ? m_rotationDefaultSpeed : ((m_horizontal < 0f) ? (m_rotationDefaultSpeed * -1) : 0f);
        m_triggerJump = Input.GetKeyDown(KeyCode.Space);
        m_triggerBark = Input.GetKeyDown(KeyCode.Mouse1);
       
       

        
    }

    
    // Movement and  character rotation
    
    private void Move()
    {
        if (Methods.AnimationBeingPlayed(m_animator, AnimationNames.Walk) || Methods.AnimationBeingPlayed(m_animator, AnimationNames.Run) || Methods.AnimationBeingPlayed(m_animator, AnimationNames.Jump))
        {
            //Move
            if (m_isRunning)
                m_rigidbody.velocity = transform.forward * m_vertical * m_runningSpeed;
            else if (m_isWalking)
                m_rigidbody.velocity = transform.forward * m_vertical * m_walkingSpeed;

            //Rotate
            m_rotationVelocity = new Vector3(0f, m_rotationSpeed, 0f);
            m_rotation = Quaternion.Euler(m_rotationVelocity * Time.deltaTime);
            m_rigidbody.MoveRotation(m_rigidbody.rotation * m_rotation);
        }
    }

    
    // Plays animations when input is given
    
    private void UpdateAnimator()
    {
       

        if (Methods.AnimationBeingPlayed(m_animator, AnimationNames.Idle) || Methods.AnimationBeingPlayed(m_animator, AnimationNames.Walk) || Methods.AnimationBeingPlayed(m_animator, AnimationNames.Run))
        {
            m_animator.SetBool(AnimationParameters.IsWalking, m_isWalking);
            m_animator.SetBool(AnimationParameters.IsRunning, m_isRunning);

            if (m_triggerJump)
                m_animator.SetTrigger(AnimationParameters.Jump);
        }

        if (Methods.AnimationBeingPlayed(m_animator, AnimationNames.Idle))
        {
            
            if (m_triggerBark)
                m_animator.SetTrigger(AnimationParameters.Bark);
            
             
        }
       

        m_triggerJump = false;
        m_triggerBark = false;

       
    }
}
