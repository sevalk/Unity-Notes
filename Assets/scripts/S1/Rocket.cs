using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    
    [SerializeField] float mainThrust = 100f;
   
  
    Rigidbody rigidBody;
    AudioSource audioSource;
    enum State { Alive, Dying, Transcending }
    State state = State.Alive;
    // Use this for initialization
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (state == State.Alive)
        {
            RespondToThrustInput();
            
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (state != State.Alive) { return; } // ignore collisions when dead
        switch (collision.gameObject.tag)
        {
            case "Friendly":
                // do nothing
                break;
            case "Finish":
                StartSuccessSequence();
                break;
            default:
                StartDeathSequence();
                break;
        }
    }
    private void StartSuccessSequence()
    {
        state = State.Transcending;
       
      
    }
    private void StartDeathSequence()
    {
        state = State.Dying;
        
    }
    
    
    private void RespondToThrustInput()
    {
        if (Input.GetKey(KeyCode.Space)) // can thrust while rotating
        {
            ApplyThrust();
        }
       
    }

    private void ApplyThrust()
    {
     
        rigidBody.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
        
        
    }
  
}
