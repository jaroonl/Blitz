using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerController : MonoBehaviour {
public float walkSpeed = 8f;
public float jumpSpeed = 7f;
public float jumpCooldown = 0.3f;

public AudioClip jumpSound;  
private AudioSource audioSource;


//to keep our rigid body
Rigidbody rb;
//to keep the collider object
Collider coll;
//flag to keep track of whether a jump started
private bool readyToJump = true;
// Use this for initialization
void Start () {
//get the rigid body component for later use
rb = GetComponent<Rigidbody>();
//get the player collider
coll = GetComponent<Collider>();

audioSource = GetComponent<AudioSource>();
}
// Update is called once per frame
void Update ()
{
// Handle player walking
WalkHandler();
//Handle player jumping
JumpHandler();
}
// Make the player walk according to user input
void WalkHandler()
{
// Set x and z velocities to zero
rb.linearVelocity = new Vector3(0, rb.linearVelocity.y, 0);
// Distance ( speed = distance / time --> distance = speed * time)
float distance = walkSpeed * Time.deltaTime;
// Input on x ("Horizontal")
float hAxis = Input.GetAxis("Horizontal");
// Input on z ("Vertical")
float vAxis = Input.GetAxis("Vertical");
// Movement vector
Vector3 movement = new Vector3(hAxis * distance, 0f, vAxis * distance);
// Current position
Vector3 currPosition = transform.position;
// New position
Vector3 newPosition = currPosition + movement;
// Move the rigid body
rb.MovePosition(newPosition);
}
// Check whether the player can jump and make it jump
void JumpHandler()
    {
        if(Input.GetButtonDown("Jump") && readyToJump && CheckGrounded())
        {
            readyToJump = false;
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, jumpSpeed, rb.linearVelocity.z);
            
            if (jumpSound != null && audioSource != null)
                audioSource.PlayOneShot(jumpSound);
                
            Invoke(nameof(ResetJump), jumpCooldown);
        }
    }

     void ResetJump()
    {
        readyToJump = true;
    }


// Check if the object is grounded
bool CheckGrounded()
{
    float checkDistance = 0.2f;
    Vector3 position = transform.position + Vector3.down * (coll.bounds.extents.y + 0.1f);
    return Physics.CheckSphere(position, 0.1f, LayerMask.GetMask("Default")); 
}
}