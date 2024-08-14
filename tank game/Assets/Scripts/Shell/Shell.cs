using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell : MonoBehaviour
{

    //The time of seconds before the shell is removed
    public float m_MaxLifeTime = 2f;
    // The amount of damage done if the explosion is centered at the tank
    public float m_MaxDamage = 34f;
    // The maximum distance away from the explosion tanks can be and are still affected
    public float m_ExplosionRadius = 5;
    // The amount of force added to a tank at the centre of the explosion
    public float m_ExplosionForce = 100f;

    // Reference to the particls that will play on explosion
    public ParticleSystem m_ExplosionParticles;

    // Start is called before the first frame update
    private void Start()
    {
        // If isn't destroyed by then, destroy the shell after it's lifetime
        Destroy(gameObject, m_MaxLifeTime);
    }
    private void OnCollisionEnter(Collision other)
    {
        // Find the rigidbody of the collision object
        Rigidbody targetRigidBody = other.gameObject.GetComponent<Rigidbody>();

        //
        // TODO: Add code here to damage the object (Tank) we just collided with
        //

        // Unparent the particles from the shell
        m_ExplosionParticles.transform.parent = null;

        // Play the particle system
        m_ExplosionParticles.Play();

        // Once the particles have finished, destroy the game object they are on
        Destroy(m_ExplosionParticles.gameObject, m_ExplosionParticles.main.duration);

        // Destroy the shell
        Destroy(gameObject);

    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
