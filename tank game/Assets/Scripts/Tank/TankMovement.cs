using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class TankMovement : MonoBehaviour
{
    public float m_Speed = 20f;
    //How fast the tank moves forward and back
    public float m_RotationSpeed = 180f;
    //How fast the tank turn in degrees per second
    private Rigidbody m_Rigidbody;

    private float m_ForwardInputValue;
    private float m_TurnInputValue;
    private Rigidbody rbody;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
       m_Rigidbody = GetComponent<Rigidbody>();
    }
    private void OnEnable()
    {
        //When tank is turned on, make sure it is not kinematic
        m_Rigidbody.isKinematic = false;

        //also reset input values
        m_ForwardInputValue = 0;
        m_TurnInputValue = 0;
    }

    private void OnDisable ()
    {
        //When the tank is turned off, set it to kinematic so it stops moving
        m_Rigidbody.isKinematic = true;
    }



    // Update is called once per frame
    void Update()
    {
        m_ForwardInputValue = Input.GetAxis("Vertical");
        m_TurnInputValue = Input.GetAxis("Horizontal");
    }
    void FixedUpdate()
    {
        Move();
        Turn();
    }
   void Move()
    {
        //Create a vector in the direction the tank is facing with a magnitude
        //Based on the input, speed and time between frames
        Vector3 wantedVelocity = transform.forward * m_ForwardInputValue * m_Speed;

        //Apply wantedVelocity minus the current rigidbody velocity to apply a change
        //in the velocity in the tank
        //This ignores the mass in the tank
        m_Rigidbody.AddForce(wantedVelocity - m_Rigidbody.velocity, ForceMode.VelocityChange);
    }
   void Turn()
    {
        //Determining the number of degrees to be turned based on the input.
        //Speed and time between frames
        float turnValue = m_TurnInputValue * m_RotationSpeed * Time.deltaTime;

        //Make this into a rotation around the y axis
        Quaternion turnRotation = Quaternion.Euler(0f, turnValue, 0f);

        //Apply this rotation to the rigidbody's rotation
        m_Rigidbody.MoveRotation(transform.rotation * turnRotation);
    }
}
