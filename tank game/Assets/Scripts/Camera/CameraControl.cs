using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public float m_DampTime = 0.2f;

    public Transform m_target;

    private Vector3 m_MoveVelocity;
    private Vector3 m_DesiredPosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    void Awake()
    {
        //Remove to manually add target to follow instead
        m_target = GameObject.FindGameObjectWithTag("Player").transform;
    }

   
    private void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        m_DesiredPosition = m_target.position;
        transform.position = Vector3.SmoothDamp(transform.position, m_DesiredPosition, ref m_MoveVelocity, m_DampTime);
    }
}
